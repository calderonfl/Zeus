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
            //modelBuilder.Entity<KadabraUser>().ToTable("KadabraUser", "dbo");
            //modelBuilder.Entity<KadabraUser>().Property(p => p.UserName).HasColumnName("FirstName");
            //modelBuilder.Entity<KadabraUser>().Property(p => p.Id).HasColumnName("UserId");
            //modelBuilder.Entity<KadabraUser>().HasMany(p => p.Leagues).WithRequired(s => s.User).HasForeignKey(p => p.UserId);
            //modelBuilder.Entity<KadabraUser>().HasMany(u => u.UserTournaments).WithRequired(t => t.User).HasForeignKey(t => t.UserId);

            //modelBuilder.Entity<KadabraUserTournament>().HasKey(ut => ut.Id);

            //modelBuilder.Entity<KadabraTournament>().ToTable("KadabraTournament", "dbo");
            //modelBuilder.Entity<KadabraTournament>().HasMany(t => t.Tournaments).WithRequired(ut => ut.Tournament).HasForeignKey(ut => ut.TournamentId);
            //modelBuilder.Entity<KadabraTournament>().HasMany(t => t.Matches).WithRequired(m => m.Tournament).HasForeignKey(m => m.TournamentId);

            //modelBuilder.Entity<KadabraMatchDay>().ToTable("KadabraMatchDay", "dbo");
            //modelBuilder.Entity<KadabraMatchDay>().HasMany(md => md.Matches).WithRequired(m => m.MatchDay).HasForeignKey(m => m.MatchDayId);

            //modelBuilder.Entity<KadabraMatch>().ToTable("KadabraMatch", "dbo");
            

            modelBuilder.Entity<KadabraTeam>().ToTable("KadabraTeam", "dbo");
            //modelBuilder.Entity<KadabraTeam>().HasMany(t => t.MatchesAway).WithRequired(m => m.TeamAway).HasForeignKey(m => m.TeamAwayId);
            //modelBuilder.Entity<KadabraTeam>().HasMany(t => t.MatchesHome).WithRequired(m => m.TeamHome).HasForeignKey(m => m.TeamHomeId);


            
            //modelBuilder.Entity<KadabraTeam>().ToTable("KadabraTeam", "dbo");

            // Una prediccion es sobre un encuentro.
            //modelBuilder.Entity<KadabraPrediction>().ToTable("KadabraPrediction", "dbo").HasRequired(p => p.Match).WithRequiredPrincipal(p => p.Prediction);

            //modelBuilder.Entity<KadabraMatch>().ToTable("KadabraMatch", "dbo").HasOptional(m => m.Prediction).WithRequired(m => m.Match);
            ////modelBuilder.Entity<KadabraTournament>().ToTable("KadabraTournament", "dbo").HasMany(t => t.Matches).WithRequired
            ////modelBuilder.Entity<KadabraUserTournament>().HasRequired<KadabraUser>(s => s.User).WithMany(g => g.UserTournaments).HasForeignKey(s => s.UserId);

            //modelBuilder.Entity<IdentityRole>().ToTable("KadabraRole", "dbo");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("KadabraUserRole", "dbo");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("KadabraUserClaim", "dbo");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("KadabraUserLogin", "dbo");
        }
    }
}
