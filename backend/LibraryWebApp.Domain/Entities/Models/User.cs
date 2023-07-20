using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Entities.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "FirstName name is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the FirstName is 60 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "LastName name is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the LastName is 60 characters.")]
        public string? LastName { get; set; }

    }
}
