﻿using LibraryWebApp.Domain.Entities.DataTransferObjects.Creations;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Domain.Entities.DataTransferObjects
{
    public abstract record AuthorForManipulationDto
    {
        [Required(ErrorMessage = "Author name is a required field.")]
        [MaxLength(120, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; init; }

        public DateTime DateOfBirth { get; init; }

        public IEnumerable<BookForCreationDto>? Books { get; init; } = null;
    }
}
