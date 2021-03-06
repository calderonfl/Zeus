﻿using System.ComponentModel.DataAnnotations;

namespace Kadabra.Model.Team
{
    public class TeamAddModel
    {
        [Display(Name = "Nombre")]
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string CountryId { get; set; }
        [Display(Name = "Acrónimo")]
        [StringLength(3, MinimumLength = 2)]
        public string TeamKey { get; set; }
        public string ImageFlag { get; set; }
    }
}
