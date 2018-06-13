using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraUserTournament
    {
        [Key]
        public string Id { get; set; }
        public int? Points { get; set; }
        public int? Accuracy { get; set; }
        public int? TotalPredictions { get; set; }
        public int? IndexPoints { get; set; }
        public int? IndexAccuracy { get; set; }
        public int? RankPoints { get; set; }
        public int? RankAccuracy { get; set; }
        public int? OldRankPoints { get; set; }
        public int? OldRankAccuracy { get; set; }
        public int? VisibleRankPoints { get; set; }
        public int? VisibleRankAccuracy { get; set; }
        public string TournamentId { get; set; }
        public KadabraTournament Tournament { get; set; }
        public string UserId { get; set; }
        public KadabraUser User { get; set; }
        public KadabraPredictions Predictions { get; set; }
    }
}