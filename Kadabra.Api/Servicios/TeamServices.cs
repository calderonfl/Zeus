using System;
using System.Linq;
using System.Threading.Tasks;
using Kadabra.Model.Team.Services;
using Kadabra.Model.Team;
using Kadabra.Data;
using Kadabra.Data.Identity;
using Kadabra.Model.Country;

namespace Kadabra.Api.Servicios
{
    internal class TeamServices : ITeamServices
    {
        private bool disposedValue = false;
        private readonly IRepository<KadabraTeam> repository;

        public TeamServices(IRepository<KadabraTeam> repository)
        {
            this.repository = repository;
        }
        public async Task Add(TeamAddModel team)
        {
            await repository.Add(new KadabraTeam()
            {
                CountryId = team.CountryId,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey,
                Id= Guid.NewGuid().ToString()
            });
            await repository.Save();
        }
        public async Task Edit(TeamModel team)
        {
            await repository.Update(new KadabraTeam()
            {
                Id= team.Id,
                CountryId = team.CountryId,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey
            });
            await repository.Save();
        }
        public async Task<TeamCollectionModel> GetAll()
        {
            var entities = await repository.GetAll();
            var teams = entities.Select(team => new TeamDisplayModel()
            {
                Id = team.Id,
                Country = team.Country.Name,
                Name = team.Name,
                TeamKey = team.TeamKey
            });
            return new TeamCollectionModel(teams);
        }
        public async Task Remove(TeamIdModel team)
        {
            await repository.Delete(t => t.Id == team.Id);
            await repository.Save();
        }
        public async Task<TeamModel> Get(TeamIdModel model)
        {
            KadabraTeam team = await repository.FindOne(f => f.Id == model.Id);
            return new TeamModel()
            {
                CountryId = team.CountryId,
                Id = team.Id,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey
            };
        }
        private async Task<CountryCollectionModel> GetAllCountries()
        {
            return await new CountryServices(new RepositoryCountry()).GetAllCountries();
        }
        public async Task<TeamModelWithCountries> GetTeamWithCountries()
        {
            return await GetTeamWithCountries(null);
        }
        public async Task<TeamModelWithCountries> GetTeamWithCountries(TeamIdModel team)
        {
            var countries = await GetAllCountries();
            return await GetTeamWithCountries(team, countries);

        }
        private async Task<TeamModelWithCountries> GetTeamWithCountries(TeamIdModel team, CountryCollectionModel countries)
        {
            if (team == null) return new TeamModelWithCountries(countries);
            else
            {
                var model = await this.Get(team);
                return new TeamModelWithCountries(model, countries);
            }
        }
        protected void Dispose(bool disposing)
        {
            if (disposedValue)
            {
                if (disposing)
                {
                    
                }
            }
        }
        ~TeamServices()
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