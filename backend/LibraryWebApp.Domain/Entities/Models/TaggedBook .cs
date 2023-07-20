using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Entities.Models
{
    public class TaggedBok
    {
        [Column("AuthorId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Library))]
        public Guid LibraryId { get; set; }

        public Library? Library { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        public Book? Book { get; set; }

        public Tag Tag { get; set; } = Tag.NotStarted;
    }
}
