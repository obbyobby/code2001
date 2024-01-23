using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace _2001.Models
{
    public class Filters
    {
        [Key]
        public int FilterId { get; set; }

        [Required]
        public string FilterName { get; set; }

    }
}
