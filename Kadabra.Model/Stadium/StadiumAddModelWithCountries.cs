using Kadabra.Model.Country;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadabra.Model.Stadium
{
    public class StadiumAddModelWithCountries
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

        public CountryCollectionModel Countries { get; set; }
    }
}
