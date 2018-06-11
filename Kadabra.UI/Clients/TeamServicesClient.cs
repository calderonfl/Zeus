using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kadabra.Model.Team.Services;
using Kadabra.Model.Team;
using System.Net.Http.Headers;
using Kadabra.Model.Country;

namespace Kadabra.UI.Clients
{
    //[Dependency("ITeamServices", LoadHint.Always)]
    internal class TeamServicesClient : ITeamServices
    {
        private readonly string uriBase = "http://localhost/Kadabra.Api/";
        private readonly HttpClient apiClient;
        public TeamServicesClient()
        {
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(uriBase);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.Timeout = new TimeSpan(0, 0, 1, 0, 0);
        }

        public async Task Add(TeamAddModel team)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Team/AddTeam", team);
            response.EnsureSuccessStatusCode();
        }

        public async Task Edit(TeamModel team)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Team/EditTeam", team);
            response.EnsureSuccessStatusCode();
        }

        public async Task<TeamCollectionModel> GetAll()
        {
            HttpResponseMessage response = await apiClient.GetAsync("Kadabra/Team/GetAll");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<TeamCollectionModel>();
            else
                return new TeamCollectionModel();
        }
        public async Task<CountryCollectionModel> GetAllCountries()
        {
            HttpResponseMessage response = await apiClient.GetAsync("Kadabra/Team/GetAllCountries");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<CountryCollectionModel>();
            else
                return new CountryCollectionModel();
        }

        public async Task<TeamModel> Get(TeamIdModel teamId)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Team/Get", teamId);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<TeamModel>();
            else
                return null;
        }
        public async Task Remove(TeamIdModel team)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Team/DeleteTeam", team);
            response.EnsureSuccessStatusCode();
        }

        private bool disposedValue = false;
        protected void Dispose(bool disposing)
        {
            if (disposedValue)
            {
                if (disposing && apiClient != null)
                {
                    apiClient.Dispose();
                }
            }
        }
        ~TeamServicesClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}