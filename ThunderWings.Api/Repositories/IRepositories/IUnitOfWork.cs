namespace ThunderWings.Api.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IShoppingCartRepository ShoppingCart { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IAircraftRepository Aircraft { get; }
        void Save();
    }
}
