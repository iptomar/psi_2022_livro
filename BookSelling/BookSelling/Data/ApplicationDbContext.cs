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
            modelBuilder.Entity<Category>().HasData(
           new Category
           {
               IdCategory = 1,
               NameCategory = "Fantasy"
           },
           new Category
           {
               IdCategory = 2,
               NameCategory = "Action"
           }
           );
        }
    }
}
