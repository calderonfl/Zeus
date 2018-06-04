using System;
using System.ComponentModel.DataAnnotations;

namespace Kadabra.Data.Identity
{
    public class KadabraMatch
    {
        private KadabraMatchStatus status;
        [Key]
        public string Id { get; set; }
        public string Level { get; set; }
        public DateTime Start {get;}
        public string Home { get; set; }
        public string TeamHomeId { get; set; }
        public KadabraTeam TeamHome { get; set; }
        public string TeamAwayId { get; set; }
        public KadabraTeam TeamAway { get; set; }
        public int? ScoreHome { get; set; }
        public int? ScoreAway { get; set; }
        public bool Enabled { get; set; }
        public KadabraPrediction Prediction { get; set; }
        public string LiveStatus { get; set; }
        public string LiveScoreAway { get; set; }
        public string LiveScoreHome { get; set; }
        public KadabraMatchStatus MatchStatus
        {
            get { return GetMatchStatus(); }
            set { status = value; }
        }
        public string MatchString => string.Format("{0} {1:D} - {2:D} {3}", new string[] { TeamHome.Name, ((int)ScoreHome).ToString(), ((int)ScoreAway).ToString(), TeamAway.Name });
        private KadabraMatchStatus GetMatchStatus()
        {
            if (Prediction == null || Prediction.Points == null)
                return GetMatchStatusWithOutPrediction();
            if (Prediction.Points > 0 && Prediction.Points.Equals(Prediction.MaxPoints))
                return KadabraMatchStatus.MatchStatusExact;
            else
            {
                if (Prediction.Points > 0)
                    return KadabraMatchStatus.MatchStatusCorrect;
                else
                    return KadabraMatchStatus.MatchStatusIncorrect;
            }
         }
        private KadabraMatchStatus GetMatchStatusWithOutPrediction()
        {
            if (ScoreHome != null && ScoreAway != null)
                return KadabraMatchStatus.MatchStatusFinished;
            if (Start < DateTime.Now)
                return KadabraMatchStatus.MatchStatusPending;
            return KadabraMatchStatus.MatchStatusOpen;
        }
    }
}