using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadabra.Data.Identity
{
    public class KadabraPrediction
    {
        [Key]
        public string Id { get; set; }
        public string MatchId { get; set; }
        public KadabraMatch Match { get; set; }
        public int? ScoreHome { get; set; }
        public int? ScoreAway { get; set; }
        public int? Points { get; private set; }
        public int? MaxPoints { get; set; }
        public string UserTournamentId { get; set; }
        public KadabraUserTournament User { get; set; }
        public KadabraTeamWinner GetWinner()
        {
            if (ScoreHome > ScoreAway)
                return KadabraTeamWinner.HomeWinner;
            if (ScoreAway > ScoreHome)
                return KadabraTeamWinner.AwayWinner;
            return KadabraTeamWinner.DrawMatch;
        }
        public KadabraPredictionStatus CalculatePoints()
        {
            if(Match.MatchStatus == KadabraMatchStatus.MatchStatusFinished)
            {
                if (ScoreHome == Match.Score?.ScoreHome && ScoreAway == Match.Score?.ScoreAway)
                    return KadabraPredictionStatus.MatchStatusExact;
                else
                    return CalculatePointsNotExactResult();
            }
            return 0;
        }
        private KadabraPredictionStatus CalculatePointsNotExactResult()
        {
            if (GetWinner() == Match.GetWinner())
                return KadabraPredictionStatus.MatchStatusCorrect;
            else
                return KadabraPredictionStatus.MatchStatusIncorrect;
        }
    }
}
