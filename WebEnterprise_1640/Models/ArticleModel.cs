using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEnterprise_1640.Models
{
    public class ArticleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SubmitDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string UserId { get; set; }
        public UserModel User { get; set; }

        [Required]
        [ForeignKey("Magazines")]
        public int MagazineId { get; set; }
        public MagazineModel? Magazine { get; set; }


        [NotMapped]
        public List<CommentModel> Comments { get; set; }

        [NotMapped]
        public List<DocumentModel> Documents { get; set; }
    }
    public class ArticleViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SubmitDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string UserId { get; set; }

        public int MagazineId { get; set; }
    }
}