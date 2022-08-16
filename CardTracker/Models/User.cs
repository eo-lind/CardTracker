using System.ComponentModel.DataAnnotations;

namespace CardTracker.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
