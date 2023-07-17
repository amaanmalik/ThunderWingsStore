namespace ThunderWings.Api.Services.Order
{
    /// <summary>
    /// Represents the service responsible for managing orders.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Submits an order for the specified user.
        /// </summary>
        /// <param name="userId">The ID of the user submitting the order.</param>
        /// <returns>The order confirmation message.</returns>
        Task<string> SubmitOrderAsync(string userId);
    }
}
