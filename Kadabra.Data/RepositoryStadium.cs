using Kadabra.Data.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System;

namespace Kadabra.Data
{
    public class RepositoryStadium : Repository<KadabraStadium>
    {
        public async override Task<IEnumerable<KadabraStadium>> GetAll()
        {
            var query = (await GetQuery()).Include<KadabraStadium, KadabraCountry>(t => t.Country);
            return query.AsEnumerable();
        }
        public async override Task<KadabraStadium> FindOne(Expression<Func<KadabraStadium, bool>> criteria)
        {
            var query = (await GetQuery()).Where(criteria).Include<KadabraStadium, KadabraCountry>(t => t.Country);
            return query.FirstOrDefault();
        }
    }
}
