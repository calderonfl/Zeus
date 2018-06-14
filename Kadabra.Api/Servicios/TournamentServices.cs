using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Kadabra.Data;
using Kadabra.Data.Identity;
using Kadabra.Model.Tournament;

namespace Kadabra.Api.Services
{
    internal class TournamentServices : ITournamentServices
    {
        private readonly IRepository<KadabraTournament> repository;

        public TournamentServices(IRepository<KadabraTournament> repository)
        {
            this.repository = repository;
        }

        public async Task<TournamentCollectionModel> GetAllTournaments()
        {
            var entities = (await repository.GetQuery()).Include<KadabraTournament, KadabraCountry>(f => f.Country)
                .Include<KadabraTournament, KadabraTeams>(t => t.Teams).Include<KadabraTournament, KadabraMatches>(t => t.Matches);
            var teams = entities.Select(team => new TournamentDisplayModel()
            {
                Id = team.Id,
                Name = team.Name,
                Country = team.Country.Name,
                Start = team.Start,
                End = team.End,
                MatchesTotal = team.Matches.Count(),
                TeamTotal = team.Teams.Count()
            });
            return new TournamentCollectionModel(teams);
        }
    }
}