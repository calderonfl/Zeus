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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KadabraUser>().ToTable("KadabraUser", "dbo").Property(p=>p.UserName).HasColumnName("FirstName");
            modelBuilder.Entity<KadabraUser>().ToTable("KadabraUser", "dbo").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<KadabraUser>().ToTable("KadabraUser", "dbo").HasMany(p => p.UserTournaments).WithRequired(s => s.User).HasForeignKey(p => p.UserId);

            modelBuilder.Entity<KadabraMatch>().ToTable("KadabraMatch", "dbo").HasOptional(m => m.Prediction).WithRequired(m => m.Match);
            //modelBuilder.Entity<KadabraTournament>().ToTable("KadabraTournament", "dbo").HasMany(t => t.Matches).WithRequired
            //modelBuilder.Entity<KadabraUserTournament>().HasRequired<KadabraUser>(s => s.User).WithMany(g => g.UserTournaments).HasForeignKey(s => s.UserId);

            modelBuilder.Entity<IdentityRole>().ToTable("KadabraRole", "dbo");
            modelBuilder.Entity<IdentityUserRole>().ToTable("KadabraUserRole", "dbo");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("KadabraUserClaim", "dbo");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("KadabraUserLogin", "dbo");
            modelBuilder.Entity<KadabraUserTournament>().ToTable("KadabraUserTournament", "dbo").HasKey(p=>p.UserTournamentId);
        }
    }
}
