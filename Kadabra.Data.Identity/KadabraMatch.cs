using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadabra.Data.Identity
{
    public class KadabraMatch
    {
        private KadabraMatchStatus status;
        [Key]
        public string Id { get; set; }
        //public string Level { get; set; }
        public DateTime Start {get;}
        public string StadiumName { get; set; }
        public string TeamHomeId { get; set; }
        public KadabraTeam TeamHome { get; set; }
        public string TeamAwayId { get; set; }
        public KadabraTeam TeamAway { get; set; }
        public int? ScoreHome { get; set; }
        public int? ScoreAway { get; set; }
        public bool Enabled { get; set; }
        [NotMapped]
        public KadabraMatchStatus MatchStatus => GetMatchStatus();
        public string MatchString => string.Format("{0} {1:D} - {2:D} {3}", new string[] { TeamHome.Name, ((int)ScoreHome).ToString(), ((int)ScoreAway).ToString(), TeamAway.Name });
        private KadabraMatchStatus GetMatchStatus()
        {
            if (ScoreHome != null && ScoreAway != null)
                return KadabraMatchStatus.MatchStatusFinished;
            if (Start < DateTime.Now)
                return KadabraMatchStatus.MatchStatusPending;
            return KadabraMatchStatus.MatchStatusOpen;

        }
        public KadabraTeamWinner GetWinner()
        {
            if (ScoreHome > ScoreAway)
                return KadabraTeamWinner.HomeWinner;
            if (ScoreAway > ScoreHome)
                return KadabraTeamWinner.AwayWinner;
            return KadabraTeamWinner.DrawMatch;
        }
        public int MatchDay { get; set; }
        //public KadabraTournament Tournament { get; set; }
        //public KadabraMatchDay MatchDay { get; set; }
        //public string TournamentId { get; set; }
    }
}