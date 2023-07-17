
using ThunderWings.Api.Data;
using ThunderWings.Api.Models.Domain;
using ThunderWings.Api.Repositories.IRepositories;

namespace ThunderWings.Api.Repositories
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private AppDbContext _db;
        public OrderHeaderRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
