using System.ComponentModel.DataAnnotations;

namespace CardTracker.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string NameFirst { get; set; }

        [Required]
        public string NameLast { get; set; }

        [Required]
        public string ImageUrlHeadshot { get; set; }
    }
}
