using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadabra.Data.Identity
{
    public class KadabraMatch
    {
        [Key]
        public string Id { get; set; }
        public DateTime Start {get;}
        public string StadiumId { get; set; }
        public KadabraStadium Stadium { get; set; }
        public string TeamHomeId { get; set; }
        public KadabraTeam TeamHome { get; set; }
        public string TeamAwayId { get; set; }
        public KadabraTeam TeamAway { get; set; }
        public string ScoreId { get; set; }
        public KadabraScore Score { get; set; }
        public bool Enabled { get; set; }
        [NotMapped]
        public KadabraMatchStatus MatchStatus => GetMatchStatus();
        public string MatchString => string.Format("{0} {1:D} - {2:D} {3}", new string[] { TeamHome.Name, ((int)Score?.ScoreHome).ToString(), ((int)Score?.ScoreHome).ToString(), TeamAway.Name });
        private KadabraMatchStatus GetMatchStatus()
        {
            if (Score != null)
                return KadabraMatchStatus.MatchStatusFinished;
            if (Start < DateTime.Now)
                return KadabraMatchStatus.MatchStatusPending;
            return KadabraMatchStatus.MatchStatusOpen;

        }
        public KadabraTeamWinner GetWinner()
        {
            if (Score.ScoreHome > Score.ScoreAway)
                return KadabraTeamWinner.HomeWinner;
            if (Score.ScoreAway > Score.ScoreHome)
                return KadabraTeamWinner.AwayWinner;
            return KadabraTeamWinner.DrawMatch;
        }
        public int MatchDay { get; set; }
        public string TournamentId { get; set; }
        public KadabraTournament Tournament { get; set; }
        public KadabraPredictions Predictions { get; set; }
    }
}