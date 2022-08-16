using System.ComponentModel.DataAnnotations;

namespace CardTracker.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string StatusName { get; set; }
    }
}
