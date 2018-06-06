using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Kadabra.Api.Services;
using Kadabra.Model.Team;
using Newtonsoft.Json;

namespace Kadabra.UI.Controllers
{
    //[Dependency("ITeamServices", LoadHint.Always)]
    internal class TeamServicesClient : ITeamServices
    {
        private readonly string uri = "http://localhost/Kadabra.Api/Kadabra/Team";
        public Task Add(TeamAddModel team)
        {
            throw new System.NotImplementedException();
        }

        public Task Edit(TeamModel team)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TeamCollectionModel> GetAll()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<TeamCollectionModel>(await httpClient.GetStringAsync(uri));
            }
        }

        public Task Remove(TeamModel team)
        {
            throw new System.NotImplementedException();
        }
    }
}