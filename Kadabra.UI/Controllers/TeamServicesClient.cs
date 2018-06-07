﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Kadabra.Model.Team.Services;
using Kadabra.Model.Team;
using System.Net.Http.Headers;

namespace Kadabra.UI.Controllers
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

        public Task Edit(TeamModel team)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TeamCollectionModel> GetAll()
        {
            HttpResponseMessage response = await apiClient.GetAsync("Kadabra/Team/GetAll");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<TeamCollectionModel>();
            else
                return new TeamCollectionModel();
        }

        public Task Remove(TeamModel team)
        {
            throw new System.NotImplementedException();
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