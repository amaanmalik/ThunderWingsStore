using System.Text;
using ThunderWings.Api.Models.Domain;

namespace ThunderWings.Api.Services.Order
{
    public static class OrderConfirmationGenerator
    {
        public static string GenerateOrderConfirmation(OrderHeader order, List<OrderDetail> orderDetails)
        {
            StringBuilder confirmationBuilder = new StringBuilder();

            confirmationBuilder.AppendLine("Order Confirmation");
            confirmationBuilder.AppendLine("------------------");
            confirmationBuilder.AppendLine($"Order ID: {order.Id}");
            confirmationBuilder.AppendLine($"Order Date: {order.OrderDate}");
            confirmationBuilder.AppendLine($"Shipping Date: {order.ShippingDate}");
            confirmationBuilder.AppendLine($"Order Total: {order.OrderTotal}");
            confirmationBuilder.AppendLine($"Order Status: {order.OrderStatus}");
            confirmationBuilder.AppendLine($"Phone Number: {order.PhoneNumber}");
            confirmationBuilder.AppendLine($"Street Address: {order.StreetAddress}");
            confirmationBuilder.AppendLine($"City: {order.City}");
            confirmationBuilder.AppendLine($"State: {order.State}");
            confirmationBuilder.AppendLine($"Postal Code: {order.PostalCode}");
            confirmationBuilder.AppendLine($"Name: {order.Name}");

            confirmationBuilder.AppendLine("Order Details");
            confirmationBuilder.AppendLine("-------------");

            foreach (var orderDetail in orderDetails)
            {
                confirmationBuilder.AppendLine($"Aircraft ID: {orderDetail.AircraftId}");
                confirmationBuilder.AppendLine($"Aircraft Name: {orderDetail.Aircraft.Name}");
                confirmationBuilder.AppendLine($"Count: {orderDetail.Count}");
                confirmationBuilder.AppendLine($"Price: {orderDetail.Price}");
                confirmationBuilder.AppendLine();
            }



            return confirmationBuilder.ToString();
        }
    }
}
