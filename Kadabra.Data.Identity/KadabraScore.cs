using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraScore
    {
        [Key]
        public string Id { get; set; }
        public string MatchId { get; set; }
        public KadabraMatch Match { get; set; }
        public int? ScoreHome { get; set; }
        public int? ScoreAway { get; set; }
    }
}