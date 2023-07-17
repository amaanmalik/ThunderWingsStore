using Microsoft.AspNetCore.Mvc;
using ThunderWings.Api.Models.Domain;
using ThunderWings.Api.Repositories.IRepositories;

namespace ThunderWings.Api.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CartService> _logger;

        public CartService(IUnitOfWork unitOfWork, ILogger<CartService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Adds an item to the shopping cart.
        /// </summary>
        /// <param name="aircraftId">The ID of the aircraft to add to the cart.</param>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The updated shopping cart.</returns>
        public ShoppingCart AddToCart(int aircraftId, string userId)
        {
            try
            {
                var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.AircraftId == aircraftId);

                if (cartFromDb != null)
                {
                    // Shopping cart exists
                    cartFromDb.Count += 1;
                    _unitOfWork.ShoppingCart.Update(cartFromDb);
                    _unitOfWork.Save();
                    return cartFromDb;
                }
                else
                {
                    var cart = new ShoppingCart
                    {
                        Count = 1,
                        AircraftId = aircraftId,
                        ApplicationUserId = userId
                    };

                    _unitOfWork.ShoppingCart.Add(cart);
                    _unitOfWork.Save();
                    return cart;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding an item to the cart.");
                throw; // Rethrow the exception for the calling code to handle
            }
        }

        /// <summary>
        /// Retrieves the cart details for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The list of cart items.</returns>
        public List<ShoppingCart> GetCartDetails(string userId)
        {
            try
            {
                var cartDetails = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == userId);
                return cartDetails.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving cart details.");
                throw; // Rethrow the exception for the calling code to handle
            }
        }

        /// <summary>
        /// Removes an item from the shopping cart.
        /// </summary>
        /// <param name="aircraftId">The ID of the aircraft to remove from the cart.</param>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The removed shopping cart item.</returns>
        public ShoppingCart RemoveFromCart(int aircraftId, string userId)
        {
            try
            {
                var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.AircraftId == aircraftId);

                if (cartFromDb != null)
                {
                    if (cartFromDb.Count <= 1)
                    {
                        _unitOfWork.ShoppingCart.Remove(cartFromDb);
                    }
                    else
                    {
                        cartFromDb.Count -= 1;
                        _unitOfWork.ShoppingCart.Update(cartFromDb);
                    }

                    _unitOfWork.Save();
                }

                return cartFromDb;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing an item from the cart.");
                throw; // Rethrow the exception for the calling code to handle
            }
        }

    }
}
