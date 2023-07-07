using LibraryWebApp.Domain.Entities.DataTransferObjects;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Creations;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Updating;
using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Interfaces.Services
{
    public interface IReviewService
    {
        Task<(IEnumerable<ReviewDto> reviews, MetaData metaData)> GetReviewsAsync(Guid authorId, Guid bookId, ReviewParameters reviewParameters, bool trackChanges);
        Task<ReviewDto> GetReviewAsync(Guid authorId, Guid bookId, Guid id, bool trackChanges);
        Task<ReviewDto> CreateReviewForBookAsync(Guid authorId, Guid bookId, ReviewForCreationDto review, bool trackChanges);
        Task DeleteReviewAsync(Guid authorId, Guid bookId, Guid reviewId, bool trackChanges);
        Task UpdateReviewAsync(Guid authorId, Guid bookId, Guid reviewId, ReviewForUpdateDto reviewForUpdate, bool autTrackChanges, bool bookTrackChanges, bool revTrackChanges);
        Task<(ReviewForUpdateDto reviewToPatch, Review reviewEntity)> GetReviewForPatchAsync
            (Guid authorId, Guid bookId, Guid reviewId, bool autTrackChanges, bool bookTrackChanges, bool revTrackChanges);
        Task SaveChangesForPatchAsync(ReviewForUpdateDto reviewToPatch, Review reviewEntity);
    }
}
