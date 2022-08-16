using System.ComponentModel.DataAnnotations;

namespace CardTracker.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public string ImageUrlLogo { get; set; }
    }
}
