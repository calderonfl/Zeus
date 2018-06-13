namespace Kadabra.Data.Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.KadabraUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.KadabraUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SocialId = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Level = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KadabraUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.KadabraUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.KadabraUserTournament",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Points = c.Int(),
                        Accuracy = c.Int(),
                        TotalPredictions = c.Int(),
                        IndexPoints = c.Int(),
                        IndexAccuracy = c.Int(),
                        RankPoints = c.Int(),
                        RankAccuracy = c.Int(),
                        OldRankPoints = c.Int(),
                        OldRankAccuracy = c.Int(),
                        VisibleRankPoints = c.Int(),
                        VisibleRankAccuracy = c.Int(),
                        TournamentId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KadabraTournament", t => t.TournamentId)
                .ForeignKey("dbo.KadabraUser", t => t.UserId)
                .Index(t => t.TournamentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.KadabraPrediction",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MatchId = c.String(nullable: false, maxLength: 128),
                        ScoreHome = c.Int(),
                        ScoreAway = c.Int(),
                        Points = c.Int(),
                        MaxPoints = c.Int(),
                        UserTournamentId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KadabraMatch", t => t.MatchId)
                .ForeignKey("dbo.KadabraUserTournament", t => t.UserTournamentId)
                .Index(t => t.MatchId)
                .Index(t => t.UserTournamentId);
            
            CreateTable(
                "dbo.KadabraMatch",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StadiumId = c.String(nullable: false, maxLength: 128),
                        TeamHomeId = c.String(nullable: false, maxLength: 128),
                        TeamAwayId = c.String(nullable: false, maxLength: 128),
                        ScoreId = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        MatchDay = c.Int(nullable: false),
                        TournamentId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KadabraTournament", t => t.TournamentId)
                .ForeignKey("dbo.KadabraStadium", t => t.StadiumId)
                .ForeignKey("dbo.KadabraTeam", t => t.TeamAwayId)
                .ForeignKey("dbo.KadabraTeam", t => t.TeamHomeId)
                .Index(t => t.StadiumId)
                .Index(t => t.TeamHomeId)
                .Index(t => t.TeamAwayId)
                .Index(t => t.TournamentId);
            
            CreateTable(
                "dbo.KadabraScore",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MatchId = c.String(),
                        ScoreHome = c.Int(),
                        ScoreAway = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KadabraMatch", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.KadabraStadium",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 128),
                        Capacity = c.Int(nullable: false),
                        Description = c.String(maxLength: 128),
                        CountryId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KadabraCountry", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.KadabraCountry",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 128),
                        CountryKey = c.String(maxLength: 128),
                        ImageFlag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KadabraTeam",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 128),
                        CountryId = c.String(nullable: false, maxLength: 128),
                        TeamKey = c.String(maxLength: 3),
                        ImageFlag = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KadabraCountry", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.KadabraTournament",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CountryId = c.String(nullable: false, maxLength: 128),
                        Logo = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        AppearInDashboard = c.Boolean(),
                        FlagImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KadabraCountry", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.KadabraTeamsInTournaments",
                c => new
                    {
                        TournamentId = c.String(nullable: false, maxLength: 128),
                        TeamId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TournamentId, t.TeamId })
                .ForeignKey("dbo.KadabraTournament", t => t.TournamentId)
                .ForeignKey("dbo.KadabraTeam", t => t.TeamId)
                .Index(t => t.TournamentId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KadabraUserTournament", "UserId", "dbo.KadabraUser");
            DropForeignKey("dbo.KadabraUserTournament", "TournamentId", "dbo.KadabraTournament");
            DropForeignKey("dbo.KadabraPrediction", "UserTournamentId", "dbo.KadabraUserTournament");
            DropForeignKey("dbo.KadabraPrediction", "MatchId", "dbo.KadabraMatch");
            DropForeignKey("dbo.KadabraMatch", "TeamHomeId", "dbo.KadabraTeam");
            DropForeignKey("dbo.KadabraMatch", "TeamAwayId", "dbo.KadabraTeam");
            DropForeignKey("dbo.KadabraMatch", "StadiumId", "dbo.KadabraStadium");
            DropForeignKey("dbo.KadabraStadium", "CountryId", "dbo.KadabraCountry");
            DropForeignKey("dbo.KadabraTournament", "CountryId", "dbo.KadabraCountry");
            DropForeignKey("dbo.KadabraTeam", "CountryId", "dbo.KadabraCountry");
            DropForeignKey("dbo.KadabraTeamsInTournaments", "TeamId", "dbo.KadabraTeam");
            DropForeignKey("dbo.KadabraTeamsInTournaments", "TournamentId", "dbo.KadabraTournament");
            DropForeignKey("dbo.KadabraMatch", "TournamentId", "dbo.KadabraTournament");
            DropForeignKey("dbo.KadabraScore", "Id", "dbo.KadabraMatch");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.KadabraUser");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.KadabraUser");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.KadabraUser");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.KadabraTeamsInTournaments", new[] { "TeamId" });
            DropIndex("dbo.KadabraTeamsInTournaments", new[] { "TournamentId" });
            DropIndex("dbo.KadabraTournament", new[] { "CountryId" });
            DropIndex("dbo.KadabraTeam", new[] { "CountryId" });
            DropIndex("dbo.KadabraStadium", new[] { "CountryId" });
            DropIndex("dbo.KadabraScore", new[] { "Id" });
            DropIndex("dbo.KadabraMatch", new[] { "TournamentId" });
            DropIndex("dbo.KadabraMatch", new[] { "TeamAwayId" });
            DropIndex("dbo.KadabraMatch", new[] { "TeamHomeId" });
            DropIndex("dbo.KadabraMatch", new[] { "StadiumId" });
            DropIndex("dbo.KadabraPrediction", new[] { "UserTournamentId" });
            DropIndex("dbo.KadabraPrediction", new[] { "MatchId" });
            DropIndex("dbo.KadabraUserTournament", new[] { "UserId" });
            DropIndex("dbo.KadabraUserTournament", new[] { "TournamentId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.KadabraUser", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.KadabraTeamsInTournaments");
            DropTable("dbo.KadabraTournament");
            DropTable("dbo.KadabraTeam");
            DropTable("dbo.KadabraCountry");
            DropTable("dbo.KadabraStadium");
            DropTable("dbo.KadabraScore");
            DropTable("dbo.KadabraMatch");
            DropTable("dbo.KadabraPrediction");
            DropTable("dbo.KadabraUserTournament");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.KadabraUser");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
