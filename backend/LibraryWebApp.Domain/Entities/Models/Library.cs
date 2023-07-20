using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Entities.Models
{
    public class Library
    {
        [Column("LibraryId")]
        public Guid Id { get; set; }
        public ICollection<TaggedBok>? BooksTag { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public User? User { get; set; }
    }
}
