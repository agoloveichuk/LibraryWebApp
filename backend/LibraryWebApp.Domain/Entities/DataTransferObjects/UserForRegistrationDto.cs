using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Domain.Entities.DataTransferObjects
{
    public record UserForRegistrationDto
    {
        [Required(ErrorMessage = "First name is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the first name is 120 characters.")]
        public string? FirstName { get; init; }

        [Required(ErrorMessage = "Last name is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the last name is 120 characters.")]
        public string? LastName { get; init; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the username is 100 characters.")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Password is required.")]
        [PasswordPropertyText]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; init; }

        public ICollection<string>? Roles { get; init; }
    }
}
