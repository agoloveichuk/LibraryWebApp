using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Entities.Models
{
    public class Author
    {
        [Column("AuthorId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Author name is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
