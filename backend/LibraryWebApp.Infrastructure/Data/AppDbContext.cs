using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Infrastructure.Data.Repository.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryWebApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Review>? Reviews { get; set; }
    }
}
