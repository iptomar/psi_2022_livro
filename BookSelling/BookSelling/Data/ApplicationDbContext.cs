using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookSelling.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
<<<<<<< Updated upstream
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
=======
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}


>>>>>>> Stashed changes
    }
}