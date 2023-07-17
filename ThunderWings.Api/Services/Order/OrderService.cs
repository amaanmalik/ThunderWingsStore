using ThunderWings.Api.Models.Domain;
using ThunderWings.Api.Repositories.IRepositories;

namespace ThunderWings.Api.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Submits an order for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user submitting the order.</param>
        /// <returns>The order confirmation message.</returns>
        public async Task<string> SubmitOrderAsync(string userId)
        {
            //To do : To cehck if ther are any  pending carts or orders.

            var orderHeader = CreateOrderHeader(userId);
            var orderDetails = CreateOrderDetails(orderHeader, userId);
            RemoveShoppingCartItems(userId);

            string orderConfirmation = GenerateOrderConfirmation(orderHeader);
            return orderConfirmation;
        }

        /// <summary>
        /// Gets the price of an aircraft based on its quantity in the shopping cart.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart item.</param>
        /// <returns>The price of the aircraft.</returns>
        private decimal GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            Aircraft aircraft = _unitOfWork.Aircraft.Get(P => P.Id == shoppingCart.AircraftId);
            return aircraft.Price;
        }

        /// <summary>
        /// Creates an order header for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The created order header.</returns>
        private OrderHeader CreateOrderHeader(string userId)
        {
            double total = 0;
            var cartFromDb = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId);
            var user = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            foreach (var cart in cartFromDb)
            {
                cart.Price = Convert.ToDouble(GetPriceBasedOnQuantity(cart));
                total += cart.Price * cart.Count;
            }

            var orderHeader = new OrderHeader
            {
                ApplicationUserId = userId,
                OrderTotal = total,
                StreetAddress = user.StreetAddress,
                City = user.City,
                Name = user.Name,
                OrderDate = DateTime.Now,
                PhoneNumber = "",
                PostalCode = user.PostalCode,
                ShippingDate = DateTime.Now.AddDays(7),
                State = user.State,
                OrderStatus = "Submitted" // ToDo : 
            };

            _unitOfWork.OrderHeader.Add(orderHeader);
            _unitOfWork.Save();

            return orderHeader;
        }

        /// <summary>
        /// Creates order details for the specified order header and user.
        /// </summary>
        /// <param name="orderHeader">The order header.</param>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The list of created order details.</returns>
        private List<OrderDetail> CreateOrderDetails(OrderHeader orderHeader, string userId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId);
            var orderDetails = new List<OrderDetail>();

            foreach (var cart in cartFromDb)
            {
                var orderDetail = new OrderDetail
                {
                    AircraftId = cart.AircraftId,
                    OrderHeaderId = orderHeader.Id,
                    Price = cart.Price,
                    Count = cart.Count
                };

                orderDetails.Add(orderDetail);
                _unitOfWork.OrderDetail.Add(orderDetail);
                _unitOfWork.Save();
            }

            return orderDetails;
        }

        /// <summary>
        /// Removes all items from the shopping cart for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        private void RemoveShoppingCartItems(string userId)
        {
            var shoppingCarts = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).ToList();
            _unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Generates an order confirmation based on the order header and order details.
        /// </summary>
        /// <param name="orderHeader">The order header.</param>
        /// <param name="orderDetails">The list of order details.</param>
        /// <returns>The order confirmation message.</returns>
        private string GenerateOrderConfirmation(OrderHeader orderHeader)
        {
            var orderDetails = _unitOfWork.OrderDetail.GetAll(u => u.OrderHeaderId == orderHeader.Id, includeProperties: "Aircraft").ToList();
            string orderConfirmation = OrderConfirmationGenerator.GenerateOrderConfirmation(orderHeader, orderDetails);
            return orderConfirmation;
        }
    }
}
