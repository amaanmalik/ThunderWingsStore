using System.Linq.Expressions;
using ThunderWings.Api.Data;
using ThunderWings.Api.Models.Domain;
using ThunderWings.Api.Models.DTO;
using ThunderWings.Api.Repositories.IRepositories;

namespace ThunderWings.Api.Repositories
{
    public class AircraftRepository : Repository<Aircraft>, IAircraftRepository
    {
        private AppDbContext _db;
        public AircraftRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Aircraft> SearchJets(SearchRequestDto requestDto)
        {
            IQueryable<Aircraft> query = dbSet;

            if (!string.IsNullOrEmpty(requestDto.Name))
            {
                query = query.Where(a => a.Name.Contains(requestDto.Name));
            }

            if (!string.IsNullOrEmpty(requestDto.Role))
            {
                query = query.Where(a => a.Role.Contains(requestDto.Role));
            }

            if (!string.IsNullOrEmpty(requestDto.Manufacturer))
            {
                query = query.Where(a => a.Manufacturer.Contains(requestDto.Manufacturer));
            }

            // Apply pagination
            query = query.Skip((requestDto.Page - 1) * requestDto.PageSize).Take(requestDto.PageSize);

            return query.ToList();
        }
    }
}
