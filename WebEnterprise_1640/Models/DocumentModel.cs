using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEnterprise_1640.Models
{
    public class DocumentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string File { get; set; }

        public string Image { get; set; }

        [Required]
        [ForeignKey("Articles")]
        public int ArticleId { get; set; }
        public ArticleModel Article { get; set; }

    }
}
