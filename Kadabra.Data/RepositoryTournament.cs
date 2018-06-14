using Kadabra.Data.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kadabra.Data
{
    public class RepositoryTournament : Repository<KadabraTournament>
    {
        public async override Task<IEnumerable<KadabraTournament>> GetAll()
        {
            return (await GetQuery()).Include<KadabraTournament, KadabraCountry>(f => f.Country)
                .Include<KadabraTournament, KadabraTeams>(t => t.Teams).Include<KadabraTournament, KadabraMatches>(t => t.Matches).AsEnumerable();
        }
        public async override Task<KadabraTournament> FindOne(Expression<Func<KadabraTournament, bool>> criteria)
        {
            var query = (await GetQuery()).Where(criteria).Include<KadabraTournament, KadabraCountry>(t => t.Country)
                .Include<KadabraTournament, KadabraTeams>(t => t.Teams).Include<KadabraTournament, KadabraMatches>(t => t.Matches);
            return query.FirstOrDefault();
        }
    }
}
