using System;
using System.Threading.Tasks;
using Kadabra.Api.Services;
using Kadabra.Model.Team;

namespace Kadabra.Api.Controllers
{
    internal class TeamServices : ITeamServices
    {
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
            
            TeamCollectionModel collection = new TeamCollectionModel(new[] { new TeamModel() { Id = Guid.NewGuid().ToString(), Country="Costa Rica1", TeamKey="CRC", Name="Costa Rica", ImageFlag="" } });
            await Task.Delay(0);
            return collection;
        }

        public Task Remove(TeamModel team)
        {
            throw new System.NotImplementedException();
        }
    }
}