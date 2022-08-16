using System.ComponentModel.DataAnnotations;

namespace CardTracker.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        [Required]
        public string MfrName { get; set; }
    }
}
