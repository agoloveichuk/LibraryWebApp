using LibraryWebApp.Domain.Entities.Models;

namespace LibraryWebApp.Domain.Entities.DataTransferObjects
{
    public record BookDto(Guid Id, string Title, string Cover, string Content, Genre Genre, decimal Rating);
}
