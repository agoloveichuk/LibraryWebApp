using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Entities.DataTransferObjects
{
    public abstract record ReviewForManipulationDto
    {
        [Required(ErrorMessage = "Review message is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the Message is 60 characters.")]
        public string? Message { get; init; }

        [Required(ErrorMessage = "Review reviewer is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the Reviewer url is 60 characters")]
        public string? Reviewer { get; init; }

        [Required(ErrorMessage = "Rating score is a required field.")]
        [Range(0, 10, ErrorMessage = "Min value = 0, Max value = 10")]
        public decimal Score { get; init; }
    }
}
