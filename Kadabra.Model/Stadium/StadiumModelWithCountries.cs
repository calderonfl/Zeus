using System.Linq;
using Kadabra.Model.Country;
using System.ComponentModel.DataAnnotations;

namespace Kadabra.Model.Stadium
{
    public class StadiumModelWithCountries
    {
        public StadiumModelWithCountries() { }
        public StadiumModelWithCountries(CountryCollectionModel countries)
        {
            Countries = countries;
        }
        public StadiumModelWithCountries(StadiumModel model, CountryCollectionModel countries) : this (countries)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            Capacity = model.Capacity;
            ImageUrl = model.ImageUrl;
            CountryId = model.CountryId;
        }
        public string Id { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(256, MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Capacidad")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false, HtmlEncode = false)]
        public int Capacity { get; set; }
        [Display(Name = "Imagen")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "País")]
        public string CountryId { get; set; }

        public string CountryName
        {
            get
            {
                if (CountryId == "")
                    return "";
                return Countries?.Where(c => c.Id == CountryId).FirstOrDefault()?.Name;
            }
        }
        public CountryCollectionModel Countries { get; set; }
    }
}
