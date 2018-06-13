using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraStadium
    {
        [Key]
        public string Id { get; set; }
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }
        public int Capacity { get; set; }
        [StringLength(128, MinimumLength = 3)]
        public string Description { get; set; }
        public string CountryId { get; set; }
        public string ImageUrl { get; set; }

        public KadabraCountry Country { get; set; }
        public KadabraMatches Matches { get; set; }
    }
}
