using ThunderWings.Api.Data;
using ThunderWings.Api.Models.Domain;
using ThunderWings.Api.Repositories;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    private AppDbContext _db;
    public ApplicationUserRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }
}