using LibraryWebApp.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryWebApp.Infrastructure.Data.Repository.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData
            (
                new Author
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Name = "J.K. Rowling",
                    DateOfBirth = new DateTime(1965, 7, 31, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "Agatha Christie",
                    DateOfBirth = new DateTime(1890, 9, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new Author
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    Name = "Jane Austen",
                    DateOfBirth = new DateTime(1775, 12, 16, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
