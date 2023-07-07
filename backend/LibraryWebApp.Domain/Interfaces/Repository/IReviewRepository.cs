using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
