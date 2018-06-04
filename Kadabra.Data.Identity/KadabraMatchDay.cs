namespace Kadabra.Data.Identity
{
    public class KadabraMatchDay
    {
        public int MatchDay { get; set; }
        public string Level { get; set; }
        public KadabraMatches Matches { get; set; }
        public void AddMatch(KadabraMatch match)
        {
            Matches.Add(match);
        }
    }
}
