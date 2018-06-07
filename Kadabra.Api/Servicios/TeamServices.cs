using System;
using System.Linq;
using System.Threading.Tasks;
using Kadabra.Model.Team.Services;
using Kadabra.Model.Team;
using Kadabra.Data;
using Kadabra.Data.Identity;

namespace Kadabra.Api.Servicios
{
    internal class TeamServices : ITeamServices
    {
        private bool disposedValue = false;
        private readonly Repository repository;

        public TeamServices(Repository repository)
        {
            this.repository = repository;
        }
        public async Task Add(TeamAddModel team)
        {
            await repository.Agregar(new KadabraTeam()
            {
                Country = team.Country,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey,
                Id= Guid.NewGuid().ToString()
            });
        }
        public async Task Edit(TeamModel team)
        {
            await repository.Update<KadabraTeam>(new KadabraTeam()
            {
                Id= team.Id,
                Country = team.Country,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey
            });
        }
        public async Task<TeamCollectionModel> GetAll()
        {
            var entities = await repository.GetAll<KadabraTeam>();
            var teams = entities.Select(team => new TeamModel()
            {
                Country = team.Country,
                Id = team.Id,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey
            });
            return new TeamCollectionModel(teams);
        }
        public async Task Remove(TeamModel team)
        {
            await repository.Delete<KadabraTeam>(t => t.Id == team.Id);
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