using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraTeam
    {
        [Key]
        public string Id { get; set; }
        [StringLength(128, MinimumLength=15)]
        public string Name { get; set; }
        [StringLength(128, MinimumLength = 15)]
        public string Country { get; set; }
        public string TeamKey { get; set; }
        public string ImageSmallUrl { get; set; }
        public string ImageBigUrl { get; set; }

        public KadabraMatches MatchesHome { get; set; }
        public KadabraMatches MatchesAway { get; set; }
    }
}
