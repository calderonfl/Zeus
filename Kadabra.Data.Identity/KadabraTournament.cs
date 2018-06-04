using System;
using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraTournament
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Flag { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int? MinAccuracyPredictions { get; set; }
        public int? MatchDays { get; set; }
        public bool? AppearInDashboard { get; set; }
        public bool? AppearInLeaderboards { get; set; }
        public KadabraMatches Matches { get; set; }
        public string FlagImageUrl { get; set; }
        public KadabraUserTournaments Tournaments { get; set; }
    }
}