using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.RequestFeatures;

namespace LibraryWebApp.Domain.Interfaces.Repository
{
    public interface IReviewRepository
    {
        Task<PagedList<Review>> GetReviewsAsync(Guid bookId, ReviewParameters reviewParameters, bool trackChanges);
        Task<Review> GetReviewAsync(Guid bookId, Guid id, bool trackChanges);
        void CreateReviewForBook(Guid bookId, Review review);
        void DeleteReview(Review review);
    }
}
