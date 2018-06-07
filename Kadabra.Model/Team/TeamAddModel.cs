using System.ComponentModel.DataAnnotations;

namespace Kadabra.Model.Team
{
    public class TeamAddModel
    {
        [StringLength(128, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(128, MinimumLength = 3)]
        public string Country { get; set; }
        [StringLength(3, MinimumLength = 3)]
        public string TeamKey { get; set; }
        public string ImageFlag { get; set; }
    }
}
