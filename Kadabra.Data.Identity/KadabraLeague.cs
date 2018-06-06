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
        public int? MemberCount => Users.Count;
        public KadabraLeagueStatus Status { get; set; }
        public bool Enabled { get; set; }
        public string CoverPhotoUrl { get; set; }
        public string UserId { get; set; }
        // Usuario que la creo
        public KadabraUser User { get; set; }
        // Usuarios en la liga
        public KadabraUsers Users { get; set; }
        // Torneo
        public KadabraTournaments Tournaments { get; set; }
    }
}
