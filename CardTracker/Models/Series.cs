using System.ComponentModel.DataAnnotations;

namespace CardTracker.Models
{
    public class Series
    {
        public int Id { get; set; }

        [Required]
        public string SeriesName { get; set; }

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
