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
        private readonly IRepository repository;

        public TeamServices(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task Add(TeamAddModel team)
        {
            await repository.Add(new KadabraTeam()
            {
                Country = team.Country,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey,
                Id= Guid.NewGuid().ToString()
            });
            await repository.Save();
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
            await repository.Save();
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
        public async Task Remove(TeamIdModel team)
        {
            await repository.Delete<KadabraTeam>(t => t.Id == team.Id);
            await repository.Save();
        }
        public async Task<TeamModel> Get(TeamIdModel model)
        {
            KadabraTeam team = await repository.FindOne<KadabraTeam>(f => f.Id == model.Id);
            return new TeamModel()
            {
                Country = team.Country,
                Id = team.Id,
                ImageFlag = team.ImageFlag,
                Name = team.Name,
                TeamKey = team.TeamKey
            };
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