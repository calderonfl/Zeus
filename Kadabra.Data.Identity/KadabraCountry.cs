using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraCountry
    {
        [Key]
        public string Id { get; set; }
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(128, MinimumLength = 2)]
        public string CountryKey { get; set; }
        public string ImageFlag { get; set; }
        public KadabraTeams Teams { get; set; }
        public KadabraStadiums Stadiums { get; set; }
        public KadabraTournaments Tournaments { get; set; }
    }
}
