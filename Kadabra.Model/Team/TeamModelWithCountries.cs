using System.Linq;
using Kadabra.Model.Country;
using System.ComponentModel.DataAnnotations;

namespace Kadabra.Model.Team
{
    public class TeamModelWithCountries
    {
        public TeamModelWithCountries() { }
        public TeamModelWithCountries(CountryCollectionModel countries)
        {
            Countries = countries;
        }
        public TeamModelWithCountries(TeamModel model, CountryCollectionModel countries) : this(countries)
        {
            Id = model.Id;
            Name = model.Name;
            ImageFlag = model.ImageFlag;
            CountryId = model.CountryId;
            TeamKey = model.TeamKey;
        }
        public string Id { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "País")]
        [StringLength(128, MinimumLength = 3)]
        public string Country { get; set; }
        [Display(Name = "Acrónimo")]
        [StringLength(3, MinimumLength = 2)]
        public string TeamKey { get; set; }
        [Display(Name = "Imagen")]
        public string ImageFlag { get; set; }
        [Required]
        [Display(Name = "País")]
        public string CountryId { get; set; }
        public string CountryName
        {
            
            get
            {
                if (CountryId == "")
                    return string.Empty;
                return Countries?.Where(c => c.Id == CountryId).FirstOrDefault()?.Name;
            }
        }
        public CountryCollectionModel Countries { get; set; }
    }
}
