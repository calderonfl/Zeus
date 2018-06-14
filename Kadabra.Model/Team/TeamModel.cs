using System.ComponentModel.DataAnnotations;

namespace Kadabra.Model.Team
{
    public class TeamModel
    {
        public string Id { get; set; }
        [Display(Name="Nombre")]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "País")]
        public string CountryId { get; set; }
        [Display(Name = "Acrónimo")]
        [StringLength(3, MinimumLength = 2)]
        public string TeamKey { get; set; }
        [Display(Name = "Dirección de la imagen")]
        public string ImageFlag { get; set; }
    }
}
