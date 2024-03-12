using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEnterprise_1640.Models
{
    public class UserModel : IdentityUser<string>
    {
        [Required]
        public string? FullName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? PersonalImage { get; set; }

        [Required]
        [ForeignKey("Faculties")]

        public int FacultyId { get; set; }
        public FacultyModel Faculty { get; set; }


        [NotMapped]
        //public List<ArticleModel> Articles { get; set; } = new List<ArticleModel>();

        public List<ArticleModel> Articles { get; set; }

        [NotMapped]
        //public List<CommentModel> Comments { get; set; } = new List<CommentModel>();

        public List<CommentModel> Comments { get; set; }

    }
}
