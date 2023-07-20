namespace LibraryWebApp.Domain.Entities.Exceptions
{
    public sealed class AuthorCollectionBadRequest : BadRequestException
    {
        public AuthorCollectionBadRequest()
            : base("Author collection sent from a client is null.")
        {
        }
    }
}
