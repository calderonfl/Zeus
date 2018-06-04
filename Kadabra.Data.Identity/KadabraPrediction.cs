using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraPrediction
    {
        [Key]
        public string Id { get; set; }
        public string MatchId { get; set; }
        public KadabraMatch Match { get; set; }
        public int? ScoreHome { get; set; }
        public int? ScoreAway { get; set; }
        public int? Points { get; set; }
        public int? MaxPoints { get; set; }
        public int DescribeContents => 0;
        public string UserId { get; set; }
        public KadabraUser User { get; set; }
    }
}
