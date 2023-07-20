using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApp.Domain.Entities.Models
{
    public class Book
    {
        [Column("BookId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Book title is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the Title is 60 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Book cover is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the Cover url is 60 characters")]
        public string? Cover { get; set; }

        [Required(ErrorMessage = "Book content is a required field.")]
        [MaxLength(1200, ErrorMessage = "Maximum length for the Content is 60 characters.")]
        public string? Content { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Rating score is a required field.")]
        [Range(0, 10, ErrorMessage = "Min value = 0, Max value = 10")]
        public decimal Rating { get; set; }

        public ICollection<Review>? Reviews { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        public Author? Author { get; set; }
    }
}
