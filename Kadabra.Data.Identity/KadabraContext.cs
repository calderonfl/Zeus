using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KadabraScore>().ToTable("KadabraScore", "dbo");
            modelBuilder.Entity<KadabraScore>().HasRequired(s => s.Match).WithOptional(m => m.Score);
            modelBuilder.Entity<KadabraStadium>().ToTable("KadabraStadium", "dbo");
            modelBuilder.Entity<KadabraStadium>().HasRequired(s => s.Country).WithMany(c => c.Stadiums).HasForeignKey(s => s.CountryId);
            modelBuilder.Entity<KadabraCountry>().ToTable("KadabraCountry", "dbo");
            modelBuilder.Entity<KadabraCountry>().HasMany(c => c.Teams).WithRequired(t => t.Country).HasForeignKey(tc => tc.CountryId);
            modelBuilder.Entity<KadabraCountry>().HasMany(c => c.Stadiums).WithRequired(s => s.Country).HasForeignKey(sc => sc.CountryId);
            modelBuilder.Entity<KadabraCountry>().HasMany(c => c.Tournaments).WithRequired(t => t.Country).HasForeignKey(tc => tc.CountryId);
            modelBuilder.Entity<KadabraTeam>().HasRequired(t => t.Country).WithMany(c => c.Teams).HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<KadabraTeam>().ToTable("KadabraTeam", "dbo");
            modelBuilder.Entity<KadabraMatch>().ToTable("KadabraMatch", "dbo");
            modelBuilder.Entity<KadabraMatch>().HasRequired(m => m.TeamAway).WithMany(t => t.MatchesAway).HasForeignKey(m => m.TeamAwayId);
            modelBuilder.Entity<KadabraMatch>().HasRequired(m => m.TeamHome).WithMany(t => t.MatchesHome).HasForeignKey(m => m.TeamHomeId);
            modelBuilder.Entity<KadabraMatch>().HasRequired(m => m.Stadium).WithMany(s => s.Matches).HasForeignKey(m => m.StadiumId);
            modelBuilder.Entity<KadabraMatch>().HasOptional(m => m.Score).WithRequired(s => s.Match);
            modelBuilder.Entity<KadabraTournament>().ToTable("KadabraTournament", "dbo");
            modelBuilder.Entity<KadabraTournament>().HasMany(t => t.Matches).WithRequired(m => m.Tournament).HasForeignKey(m => m.TournamentId);
            modelBuilder.Entity<KadabraTournament>().HasRequired(t => t.Country).WithMany(c => c.Tournaments).HasForeignKey(t => t.CountryId);
            modelBuilder.Entity<KadabraTournament>().HasMany(t => t.Teams).WithMany(ts => ts.Tournaments).Map(cs => { cs.MapLeftKey("TournamentId"); cs.MapRightKey("TeamId"); cs.ToTable("KadabraTeamsInTournaments"); });
            modelBuilder.Entity<KadabraUserTournament>().ToTable("KadabraUserTournament", "dbo");
            modelBuilder.Entity<KadabraUserTournament>().HasRequired(ut => ut.Tournament).WithMany(t => t.UserTournaments).HasForeignKey(ut => ut.TournamentId);
            modelBuilder.Entity<KadabraUserTournament>().HasMany(ut => ut.Predictions).WithRequired(p => p.User).HasForeignKey(ut => ut.UserTournamentId);
            modelBuilder.Entity<KadabraPrediction>().ToTable("KadabraPrediction", "dbo");
            modelBuilder.Entity<KadabraPrediction>().HasRequired(p => p.Match).WithMany(m => m.Predictions).HasForeignKey(p=>p.MatchId);
            modelBuilder.Entity<KadabraPrediction>().HasRequired(p => p.User).WithMany(m => m.Predictions).HasForeignKey(p => p.UserTournamentId);
            modelBuilder.Entity<KadabraUser>().ToTable("KadabraUser", "dbo");
            modelBuilder.Entity<KadabraUser>().HasMany(u => u.UserTournaments).WithRequired(ut => ut.User).HasForeignKey(ut => ut.UserId);
        }
    }
}
