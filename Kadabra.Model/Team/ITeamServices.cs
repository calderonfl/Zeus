using Kadabra.Model.Country;
using System;
using System.Threading.Tasks;

namespace Kadabra.Model.Team.Services
{
    public interface ITeamServices : IDisposable
    {
        Task Edit(TeamModel team);
        Task Remove(TeamIdModel team);
        Task Add(TeamAddModel team);
        Task<TeamCollectionModel> GetAll();
        Task<TeamModel> Get(TeamIdModel model);
        Task<TeamModelWithCountries> GetTeamWithCountries();
        Task<TeamModelWithCountries> GetTeamWithCountries(TeamIdModel stadium);
    }
}
