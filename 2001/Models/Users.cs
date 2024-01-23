using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2001.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        public int Active {  get; set; }

        [ForeignKey("CW2Filters")]
        public int FilterID { get; set; }
        public Filters Filters { get; set; }

        [ForeignKey("CW2Trail")]
        public int TrailID { get; set; }
        public Trail Trail { get; set; }


        

    }
}
