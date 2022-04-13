using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookSelling.Models;

namespace BookSelling.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<BookSelling.Models.Advertisement> Advertisement { get; set; }
        public DbSet<BookSelling.Models.User> User { get; set; }
    }
}