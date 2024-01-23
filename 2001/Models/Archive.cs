using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2001.Models
{
    public class Archive
    {
        [Key]
        public int ArchiveId { get; set; }

        [Required]
        public string ArchiveName { get; set; }

        [Required]
        public string ArchivePassword { get; set; }

        [Required]

        public string ArchiveEmail { get; set; }


        [ForeignKey("CW2Users")]
        public int UserID { get; set; }
        public Users Users { get; set; }

        



    }
}
