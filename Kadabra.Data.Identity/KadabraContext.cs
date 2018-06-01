using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Kadabra.Data.Identity
{
    public class KadabraContext : IdentityDbContext<KadabraUser> 
    {
        public KadabraContext()
            : base()
        {
        }

        public static KadabraContext Create()
        {
            return new KadabraContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
