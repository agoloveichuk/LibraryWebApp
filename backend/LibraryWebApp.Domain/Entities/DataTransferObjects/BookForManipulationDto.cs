using LibraryWebApp.Domain.Entities.DataTransferObjects.Creations;
using LibraryWebApp.Domain.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Domain.Entities.DataTransferObjects
{
    public abstract record BookForManipulationDto
    {
        [Required(ErrorMessage = "Book title is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the Title is 60 characters.")]
        public string? Title { get; init; }

        [Required(ErrorMessage = "Book cover is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the Cover url is 60 characters")]
        public string? Cover { get; init; }

        [Required(ErrorMessage = "Book content is a required field.")]
        [MaxLength(1200, ErrorMessage = "Maximum length for the Content is 60 characters.")]
        public string? Content { get; init; }

        public Genre Genre { get; init; }

        [Required(ErrorMessage = "Rating score is a required field.")]
        [Range(0, 10, ErrorMessage = "Min value = 0, Max value = 10")]
        public decimal Rating { get; init; }

        public IEnumerable<ReviewForCreationDto>? Reviews { get; init; } = null;
    }
}
