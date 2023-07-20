using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Infrastructure.Data.Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryWebApp.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
        }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<TaggedBook>? TaggedBooks { get; set; }
        public DbSet<Library>? Libraries { get; set; }
    }
}
