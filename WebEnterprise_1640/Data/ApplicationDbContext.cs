using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebEnterprise_1640.Models;

namespace WebEnterprise_1640.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel, RoleModel, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<FacultyModel> Faculties { get; set; }
        public DbSet<SemesterModel> Semesters { get; set; }
        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<DocumentModel> Documents { get; set; }
        public DbSet<MagazineModel> Magazines { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<UserModel>()
                .HasMany(e => e.Articles)
                .WithOne(e => e.User)
                .HasForeignKey(a => a.UserId)
                .IsRequired(false);

            builder.Entity<UserModel>()
               .HasMany(a => a.Comments)
               .WithOne(u => u.User)
                .HasForeignKey(a => a.UserId)
                .IsRequired(false);



            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }
    }
}