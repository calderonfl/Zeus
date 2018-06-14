using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kadabra.Model.Country.Services;
using Kadabra.Model.Country;

namespace Kadabra.UI.Clients
{
    internal class CountryServicesClient : ICountryServices
    {
        private readonly KadabraClient apiClient;
        public CountryServicesClient()
        {
            apiClient = new KadabraClient();
        }

        public async Task Add(CountryAddModel country)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Country/AddCountry", country);
            response.EnsureSuccessStatusCode();
        }

        public async Task Edit(CountryModel country)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Country/EditCountry", country);
            response.EnsureSuccessStatusCode();
        }

        public async Task<CountryCollectionModel> GetAllCountries()
        {
            HttpResponseMessage response = await apiClient.GetAsync("Kadabra/Country/GetAllCountries");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<CountryCollectionModel>();
            else
                return new CountryCollectionModel();
        }
        public async Task<CountryModel> GetCountry(CountryIdModel countryId)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Country/GetCountry", countryId);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<CountryModel>();
            else
                return null;
        }

        public async Task Remove(CountryIdModel country)
        {
            HttpResponseMessage response = await apiClient.PostAsJsonAsync("Kadabra/Country/DeleteCountry", country);
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
        ~CountryServicesClient()
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