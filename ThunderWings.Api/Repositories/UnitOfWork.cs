using ThunderWings.Api.Data;
using ThunderWings.Api.Repositories;
using ThunderWings.Api.Repositories.IRepositories;


public class UnitOfWork : IUnitOfWork
{
    private AppDbContext _db;
    public IAircraftRepository Aircraft { get; private set; }
    public IShoppingCartRepository ShoppingCart { get; private set; }
    public IApplicationUserRepository ApplicationUser { get; private set; }
    public IOrderHeaderRepository OrderHeader { get; private set; }
    public IOrderDetailRepository OrderDetail { get; private set; }
    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        ApplicationUser = new ApplicationUserRepository(_db);
        ShoppingCart = new ShoppingCartRepository(_db);
        OrderHeader = new OrderHeaderRepository(_db);
        OrderDetail = new OrderDetailRepository(_db);
        Aircraft = new AircraftRepository(_db);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
