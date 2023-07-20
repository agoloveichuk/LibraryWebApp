namespace LibraryWebApp.Domain.Entities.Exceptions
{
    public class ReviewNotFoundException : NotFoundException
    {
        public ReviewNotFoundException(Guid reviewId)
            : base($"Review with id: {reviewId} doesn't exist in the database.")

        {
        }
    }
}
