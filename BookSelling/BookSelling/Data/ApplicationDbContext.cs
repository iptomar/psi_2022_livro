﻿using BookSelling.Models;
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
        public DbSet<BookSelling.Models.Advertisement> Advertisement { get; set; }
        public DbSet<BookSelling.Models.User> User { get; set; }
    }
}