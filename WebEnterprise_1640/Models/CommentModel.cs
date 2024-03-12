using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEnterprise_1640.Models
{
    public class CommentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [ForeignKey("Users")]
        public string UserId { get; set; }
        public UserModel User { get; set; }

        [Required]
        [ForeignKey("Articles")]
        public ArticleModel Article { get; set; }
    }
}
