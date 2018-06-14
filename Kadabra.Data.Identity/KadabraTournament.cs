using System;
using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraTournament
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
        public KadabraCountry Country { get; set; }
        public string Logo { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool? AppearInDashboard { get; set; }
        public string FlagImageUrl { get; set; }

        public KadabraTeams Teams { get; set; }
        public KadabraMatches Matches { get; set;}
        public KadabraUserTournaments UserTournaments { get; set; }
    }
}