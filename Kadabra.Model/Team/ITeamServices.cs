using System;
using System.Threading.Tasks;

namespace Kadabra.Model.Team.Services
{
    public interface ITeamServices : IDisposable
    {
        Task Edit(TeamModel team);
        Task Remove(TeamModel team);
        Task Add(TeamAddModel team);
        Task<TeamCollectionModel> GetAll();
        Task<TeamModel> Get(TeamIdModel model);
    }
}
