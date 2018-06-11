using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraTeam
    {
        [Key]
        public string Id { get; set; }
        [StringLength(128, MinimumLength=3)]
        public string Name { get; set; }
        [StringLength(128, MinimumLength = 3)]
        public string CountryId { get; set; }
        public KadabraCountry Country { get; set; }
        [StringLength(3, MinimumLength = 2)]
        public string TeamKey { get; set; }
        public string ImageFlag { get; set; }
        
        //public KadabraMatches MatchesHome { get; set; }
        //public KadabraMatches MatchesAway { get; set; }
    }
}
