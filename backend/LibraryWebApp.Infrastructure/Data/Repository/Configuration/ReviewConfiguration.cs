using LibraryWebApp.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Infrastructure.Data.Repository.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData
            (
                new Review
                {
                    Id =  new Guid("00000000-0000-0000-0000-000000000001"),
                    Message = "This book was amazing!",
                    Reviewer = "John Doe",
                    Score = 9.5m,
                    BookId = new Guid("00000000-0000-0000-0000-000000000001"),
                },
                new Review
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Message = "Highly recommended!",
                    Reviewer = "Jane Smith",
                    Score = 8.8m,
                    BookId = new Guid("00000000-0000-0000-0000-000000000002"),
                },
                new Review
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    Message = "Great read!",
                    Reviewer = "David Johnson",
                    Score = 9.0m,
                    BookId = new Guid("00000000-0000-0000-0000-000000000002"),
                },
                new Review
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    Message = "Enjoyed every page!",
                    Reviewer = "Emily Brown",
                    Score = 9.2m,
                    BookId = new Guid("00000000-0000-0000-0000-000000000003"),
                },
                new Review
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000005"),
                    Message = "Well-written and captivating!",
                    Reviewer = "Michael Wilson",
                    Score = 9.4m,
                    BookId = new Guid("00000000-0000-0000-0000-000000000004"),
                },
                new Review
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000006"),
                    Message = "One of my favorites!",
                    Reviewer = "Sarah Davis",
                    Score = 9.7m,
                    BookId = new Guid("00000000-0000-0000-0000-000000000004"),
                }
            );
        }
    }
}
