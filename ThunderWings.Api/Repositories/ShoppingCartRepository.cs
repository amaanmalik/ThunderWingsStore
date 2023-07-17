

using ThunderWings.Api.Data;
using ThunderWings.Api.Models.Domain;
using ThunderWings.Api.Repositories;
using ThunderWings.Api.Repositories.IRepositories;

public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
{
    private AppDbContext _db;
    public ShoppingCartRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(ShoppingCart obj)
    {
        _db.ShoppingCarts.Update(obj);
    }
}