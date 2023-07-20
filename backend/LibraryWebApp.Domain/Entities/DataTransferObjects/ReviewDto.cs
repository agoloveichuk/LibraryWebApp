namespace LibraryWebApp.Domain.Entities.DataTransferObjects
{
    public record ReviewDto(Guid Id, string Message, string Reviewer, decimal Score);
}
