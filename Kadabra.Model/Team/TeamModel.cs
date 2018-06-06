using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadabra.Model.Team
{
    public class TeamModel
    {
        public string Id { get; set; }
        [StringLength(128, MinimumLength = 15)]
        public string Name { get; set; }
        [StringLength(128, MinimumLength = 15)]
        public string Country { get; set; }
        [StringLength(3, MinimumLength = 3)]
        public string TeamKey { get; set; }
        public string ImageFlag { get; set; }
    }
}
