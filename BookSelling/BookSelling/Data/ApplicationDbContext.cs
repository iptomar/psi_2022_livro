using BookSelling.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookSelling.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
             protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            modelBuilder.Entity<Category>().HasData(
           new Category
           {
               IdCategory = 1,
               NameCategory = "Action"
           },
           new Category
           {
               IdCategory = 2,
               NameCategory = "Adventure"
           },
           new Category
           {
               IdCategory = 3,
               NameCategory = "Comedy"
           },
           new Category
           {
               IdCategory = 4,
               NameCategory = "Drama"
           },
           new Category
           {
               IdCategory = 5,
               NameCategory = "Fantasy"
           },
           new Category
           {
               IdCategory = 6,
               NameCategory = "Science Fiction"
           },
           new Category
           {
               IdCategory = 7,
               NameCategory = "Romance"
           },
           new Category
           {
               IdCategory = 8,
               NameCategory = "Horror"
           },
           new Category
           {
               IdCategory = 9,
               NameCategory = "Manga"
           },
           new Category
           {
               IdCategory = 10,
               NameCategory = "Thriller"
           },
           new Category
           {
               IdCategory = 11,
               NameCategory = "Kids"
           },
           new Category
           {
               IdCategory = 12,
               NameCategory = "Mistery"
           },
           new Category
           {
               IdCategory = 13,
               NameCategory = "Suspance"
           },
           new Category
           {
               IdCategory = 14,
               NameCategory = "Comics Books"
           }
           );
        }

        public DbSet<BookSelling.Models.Advertisement> Advertisement { get; set; }
        public DbSet<BookSelling.Models.Category> Category { get; set; }
        public DbSet<BookSelling.Models.Utilizadores> Utilizadores { get; set; }
        public DbSet<BookSelling.Models.AdvertsCategory> AdvertsCategory { get; set; }
        public DbSet<BookSelling.Models.Favorite> Favorites { get; set; }
        public DbSet<BookSelling.Models.UserReview> UserReview { get; set; }

    }
}
