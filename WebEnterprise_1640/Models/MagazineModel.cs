using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEnterprise_1640.Models
{
    public class MagazineModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ClosureDate { get; set; }

        [Required]
        [ForeignKey("Faculties")]
        public int FacultyId { get; set; }
        public FacultyModel Faculty { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Semesters")]
        public int SemesterId { get; set; }
        public SemesterModel Semester { get; set; }

        [NotMapped]
        public List<ArticleModel> Articles { get; set; }
    }
}
