using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApp.Domain.Entities.Models
{
    public class Library
    {
        [Column("LibraryId")]
        public Guid Id { get; set; }
        public ICollection<TaggedBook>? TaggedBooks { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public User? User { get; set; }
    }
}
