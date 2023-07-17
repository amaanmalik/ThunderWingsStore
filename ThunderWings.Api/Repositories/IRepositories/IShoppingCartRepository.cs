using ThunderWings.Api.Models.Domain;

namespace ThunderWings.Api.Repositories.IRepositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart obj);
    }
}