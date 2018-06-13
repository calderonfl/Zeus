using System.ComponentModel.DataAnnotations;

namespace Kadabra.Model.Stadium
{
    public class StadiumAddModel
    {
        [Display(Name = "Nombre")]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(256, MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Capacidad")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true, HtmlEncode = false)]
        public int Capacity { get; set; }
        [Display(Name = "Imagen")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Required()]
        public string CountryId { get; set; }
    }
}
