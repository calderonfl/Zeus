using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Kadabra.Data.Identity
{
    public class KadabraContext : IdentityDbContext<KadabraUser> 
    {
        public KadabraContext()
            : base("KadabraDb")
        {
        }

        public static KadabraContext Create()
        {
            return new KadabraContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KadabraUser>().ToTable("KadabraUser");
            modelBuilder.Entity<IdentityRole>().ToTable("KadabraRole");
            modelBuilder.Entity<IdentityUserRole>().ToTable("KadabraUserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("KadabraUserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("KadabraUserLogin");
            base.OnModelCreating(modelBuilder);
        }
    }
}
