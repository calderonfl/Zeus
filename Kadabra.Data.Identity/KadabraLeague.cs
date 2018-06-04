using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraLeague
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public int? MemberCount { get; set; }
        public string FbAccount { get; set; }
        public KadabraLeagueStatus Status { get; set; }
        public bool Enabled { get; set; }
        public string CoverPhotoUrl { get; set; }
        public string UserId { get; set; }
        public KadabraUser User { get; set; }
    }
}
