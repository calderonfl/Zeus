using Kadabra.Model.Tournament;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kadabra.UI.Clients
{
    public class TournamentServicesClient : ITournamentServices
    {
        private readonly KadabraClient apiClient;
        public TournamentServicesClient()
        {
            apiClient = new KadabraClient();
        }
        public async Task<TournamentCollectionModel> GetAllTournaments()
        {
            HttpResponseMessage response = await apiClient.GetAsync("Kadabra/Tournament/GetAllTournaments");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<TournamentCollectionModel>();
            else
                return new TournamentCollectionModel();
        }
    }
}