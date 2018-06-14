using System.ComponentModel.DataAnnotations;

namespace Kadabra.Model.Stadium
{
    public class StadiumDisplayModel
    {
        public string Id { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(128, MinimumLength = 3)]
        public string Description { get; set; }
        [Required()]
        [Display(Name = "Capacidad")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false, HtmlEncode = false)]
        public int Capacity { get; set; }
        [Required()]
        [Display(Name = "País")]
        public string Country { get; set; }
    }
}
