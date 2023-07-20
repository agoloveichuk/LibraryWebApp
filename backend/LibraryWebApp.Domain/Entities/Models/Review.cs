using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApp.Domain.Entities.Models
{
    public class Review
    {
        [Column("ReviewId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Review message is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the Message is 60 characters.")]
        public string? Message { get; set; }

        [Required(ErrorMessage = "Review reviewer is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the Reviewer url is 60 characters")]
        public string? Reviewer { get; set; }

        [Required(ErrorMessage = "Rating score is a required field.")]
        [Range(0, 10, ErrorMessage = "Min value = 0, Max value = 10")]
        public decimal Score { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        public Book? Book { get; set; }
    }
}
