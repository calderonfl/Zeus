using System;
using System.Net.Http;
using Kadabra.Model.Stadium;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Kadabra.Model.Stadium.Services;

namespace Kadabra.UI.Clients
{
    public class StadiumServicesClient : IStadiumServices
    {
        private readonly string uriBase = "http://localhost/Kadabra.Api/";
        private readonly HttpClient apiClient;
        public StadiumServicesClient()
        {
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(uriBase);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.Timeout = new TimeSpan(0, 0, 1, 0, 0);
        }
        public async Task Add(StadiumAddModel stadium)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Stadium/AddStadium", stadium);
            response.EnsureSuccessStatusCode();
        }

        public async Task Edit(StadiumModel stadium)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Stadium/EditStadium", stadium);
            response.EnsureSuccessStatusCode();
        }

        public async Task<StadiumCollectionModel> GetAllStadiums()
        {
            HttpResponseMessage response = await apiClient.GetAsync("Kadabra/Stadium/GetAllStadiums");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<StadiumCollectionModel>();
            else
                return new StadiumCollectionModel();
        }

        public async Task<StadiumModel> GetStadium(StadiumIdModel stadium)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Stadium/GetStadium", stadium);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<StadiumModel>();
            else
                return null;
        }

        public async Task Remove(StadiumIdModel stadium)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Stadium/DeleteStadium", stadium);
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
        ~StadiumServicesClient()
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