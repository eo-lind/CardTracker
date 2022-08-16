using System.ComponentModel.DataAnnotations;

namespace CardTracker.Models
{
    public class Attribute
    {
        public int Id { get; set; }

        [Required]
        public string AttributeName { get; set; }
    }
}
