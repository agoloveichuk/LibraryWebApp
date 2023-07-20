using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.Interfaces.Repository;
using LibraryWebApp.Domain.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Infrastructure.Data.Repository
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<PagedList<Review>> GetReviewsAsync(Guid bookId, ReviewParameters reviewParameters, bool trackChanges)
        {
            var reviews = await FindByCondition(r => r.BookId.Equals(bookId), trackChanges)
            .OrderBy(b => b.Score)
            .ToListAsync();

            return PagedList<Review>.ToPagedList(reviews, reviewParameters.PageNumber, reviewParameters.PageSize);
        }


        public async Task<Review> GetReviewAsync(Guid bookId, Guid id, bool trackChanges) =>
            await FindByCondition(r => r.BookId.Equals(bookId) && r.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateReviewForBook(Guid bookId, Review review)
        {
            review.BookId = bookId;
            Create(review);
        }

        public void DeleteReview(Review review) => Delete(review);
    }
}
