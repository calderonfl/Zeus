using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraMatchDay
    {
        [Key]
        public string Id { get; set; }
        public int MatchDay { get; set; }
        public string Level { get; set; }
        public void AddMatch(KadabraMatch match)
        {
            Matches.Add(match);
        }
        public KadabraMatches Matches { get; set; }
    }
}
