using Kadabra.Data.Identity;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

namespace Kadabra.Data
{
    public class RepositoryTeam : Repository<KadabraTeam>
    {
        public async override Task<IEnumerable<KadabraTeam>> GetAll()
        {
            var query = (await GetQuery()).Include<KadabraTeam, KadabraCountry>(t => t.Country);
            return query.AsEnumerable();
        }

        public async override Task<KadabraTeam> FindOne(Expression<Func<KadabraTeam, bool>> criteria)
        {
            var query = (await GetQuery()).Where(criteria).Include<KadabraTeam, KadabraCountry>(t => t.Country);
            return query.FirstOrDefault();
        }
    }
}
