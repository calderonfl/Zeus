using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Kadabra.Model.Tournament
{
    public class TournamentDisplayModel
    {
        public string Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "País")]
        public string Country { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Start { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de cierre")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime End { get; set; }
        [Display(Name = "Total de encuentros")]
        public int MatchesTotal { get; set; }
        [Display(Name = "Total de equipos")]
        public int TeamTotal { get; set; }
    }
}
