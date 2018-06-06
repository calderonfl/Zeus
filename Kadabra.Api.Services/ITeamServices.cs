using Kadabra.Model.Team;
using System.Threading.Tasks;

namespace Kadabra.Api.Services
{
    public interface ITeamServices
    {
        Task Edit(TeamModel team);
        Task Remove(TeamModel team);
        Task Add(TeamAddModel team);
        Task<TeamCollectionModel> GetAll();

    }
}
