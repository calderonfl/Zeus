using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadabra.Data.Identity
{
    public class KadabraPrediction
    {
        [Key]
        public string MatchId { get; set; }
        public KadabraMatch Match { get; set; }
        public int? ScoreHome { get; set; }
        public int? ScoreAway { get; set; }
        public int? Points { get; set; }
        public int? MaxPoints { get; set; }
        public int DescribeContents => 0;
    }
}
