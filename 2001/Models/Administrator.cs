using System.ComponentModel.DataAnnotations;

namespace _2001.Models
{
    public class Administrator
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public string AdminUsername { get; set; }

        [Required]
        public string AdminPassword { get; set; }

    }
}
