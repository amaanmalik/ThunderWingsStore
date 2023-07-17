using ThunderWings.Api.Models.Domain;
using ThunderWings.Api.Models.DTO;

namespace ThunderWings.Api.Repositories.IRepositories
{
    public interface IAircraftRepository : IRepository<Aircraft>
    {
        IEnumerable<Aircraft> SearchJets(SearchRequestDto requestDto);
    }
}
