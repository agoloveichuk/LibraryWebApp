using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryWebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Cover = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Content = table.Column<string>(type: "character varying(1200)", maxLength: 1200, nullable: false),
                    Genre = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<decimal>(type: "numeric", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Reviewer = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Score = table.Column<decimal>(type: "numeric", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), "J.K. Rowling" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(1890, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Agatha Christie" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Jane Austen" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Content", "Cover", "Genre", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "The Great Gatsby is a novel...", "https://example.com/great-gatsby-cover.jpg", 5, 8.5m, "The Great Gatsby" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), "To Kill a Mockingbird is a novel...", "https://example.com/to-kill-a-mockingbird-cover.jpg", 5, 9.2m, "To Kill a Mockingbird" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003"), "1984 is a dystopian novel...", "https://example.com/1984-cover.jpg", 5, 9.0m, "1984" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000003"), "The Hobbit is a fantasy novel...", "https://example.com/the-hobbit-cover.jpg", 5, 8.8m, "The Hobbit" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "BookId", "Message", "Reviewer", "Score" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "This book was amazing!", "John Doe", 9.5m },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), "Highly recommended!", "Jane Smith", 8.8m },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), "Great read!", "David Johnson", 9.0m },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000003"), "Enjoyed every page!", "Emily Brown", 9.2m },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000004"), "Well-written and captivating!", "Michael Wilson", 9.4m },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000004"), "One of my favorites!", "Sarah Davis", 9.7m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
