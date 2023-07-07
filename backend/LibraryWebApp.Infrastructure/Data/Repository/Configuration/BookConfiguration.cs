using LibraryWebApp.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryWebApp.Infrastructure.Data.Repository.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
            (
                new Book
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Title = "The Great Gatsby",
                    Cover = "https://example.com/great-gatsby-cover.jpg",
                    Content = "The Great Gatsby is a novel...",
                    Genre = Genre.Fiction,
                    Rating = 8.5m,
                    AuthorId = new Guid("00000000-0000-0000-0000-000000000001"),
                },
                new Book
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Title = "To Kill a Mockingbird",
                    Cover = "https://example.com/to-kill-a-mockingbird-cover.jpg",
                    Content = "To Kill a Mockingbird is a novel...",
                    Genre = Genre.Fiction,
                    Rating = 9.2m,
                    AuthorId = new Guid("00000000-0000-0000-0000-000000000002"),
                },
                new Book
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    Title = "1984",
                    Cover = "https://example.com/1984-cover.jpg",
                    Content = "1984 is a dystopian novel...",
                    Genre = Genre.Fiction,
                    Rating = 9.0m,
                    AuthorId = new Guid("00000000-0000-0000-0000-000000000003"),
                },
                new Book
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    Title = "The Hobbit",
                    Cover = "https://example.com/the-hobbit-cover.jpg",
                    Content = "The Hobbit is a fantasy novel...",
                    Genre = Genre.Fiction,
                    Rating = 8.8m,
                    AuthorId = new Guid("00000000-0000-0000-0000-000000000003"),
                }
            );
        }
    }
}
