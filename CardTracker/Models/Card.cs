using System.ComponentModel.DataAnnotations;

namespace CardTracker.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrlFront { get; set; }

        [Required]
        public string ImageUrlBack { get; set; }

        [Required]
        public int NumInSeries { get; set; }

        [Required]
        public int ManufactureYear { get; set; }

        public int ManufacturerId { get; set; }

        public int StatusId { get; set; }

        public int PlayerId { get; set; }

        public int TeamId { get; set; }

        public int UserId { get; set; }

        public int AttributeId { get; set; }

        public int SeriesId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public Status Status { get; set; }

        public Player Player { get; set; }

        public Team Team { get; set; }

        public Attribute Attribute { get; set; }

        public Series Series { get; set; }
    }
}
