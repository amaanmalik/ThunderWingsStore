using ThunderWings.Api.Models.Domain;

namespace ThunderWings.Api.Services.Cart
{
    public interface ICartService
    {
        /// <summary>
        /// Adds an aircraft to the shopping cart.
        /// </summary>
        /// <param name="airCraftId">The ID of the aircraft to add to the cart.</param>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The updated shopping cart.</returns>
        ShoppingCart AddToCart(int airCraftId, string userId);

        /// <summary>
        /// Removes an aircraft from the shopping cart.
        /// </summary>
        /// <param name="aircraftId">The ID of the aircraft to remove from the cart.</param>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The removed shopping cart item.</returns>
        ShoppingCart RemoveFromCart(int aircraftId, string userId);

        /// <summary>
        /// Retrieves the cart details for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The list of cart items.</returns>
        List<ShoppingCart> GetCartDetails(string userId);
    }
}
