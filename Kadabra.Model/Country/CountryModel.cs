﻿using System.ComponentModel.DataAnnotations;

namespace Kadabra.Model.Country
{
    public class CountryModel
    {
        public string Id { get; set; }
        [Display(Name="Nombre")]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Acrónimo")]
        [StringLength(3, MinimumLength = 2)]
        public string CountryKey { get; set; }
        [Display(Name = "Imagen")]
        public string ImageFlag { get; set; }
    }
}
