namespace LibraryWebApp.Domain.Entities.Exceptions
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(Guid bookId)
            : base($"Book with id: {bookId} doesn't exist in the database.")

        {
        }
    }
}
