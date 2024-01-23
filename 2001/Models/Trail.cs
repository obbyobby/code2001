using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace _2001.Models
{
    public class Trail
    {
        [Key]
        public int TrailId { get; set; }

        [Required]
        public string Trailname { get; set; }

        [Required]
        public float Length { get; set; }

        [Required]

        public float Elevation { get; set; }

        [Required]
        public DateTime RouteTime { get; set; }

        [Required]
        public string Accessibility { get; set; }

        [Required]
        public string Routedesc { get; set; }




    }
}


