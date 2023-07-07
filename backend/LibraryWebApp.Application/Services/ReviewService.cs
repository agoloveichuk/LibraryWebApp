using AutoMapper;
using LibraryWebApp.Domain.Entities.DataTransferObjects;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Creations;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Updating;
using LibraryWebApp.Domain.Entities.Exceptions;
using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.Interfaces.Repository;
using LibraryWebApp.Domain.Interfaces.Services;
using LibraryWebApp.Domain.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryWebApp.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ReviewService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<ReviewDto> reviews, MetaData metaData)> GetReviewsAsync(Guid authorId, Guid bookId, ReviewParameters reviewParameters, bool trackChanges)
        {
            await CheckIfAuthorAndBookExist(authorId, bookId, trackChanges);

            var reviews = await _repository.Review.GetReviewsAsync(bookId, reviewParameters, trackChanges);
            var reviewsDto = _mapper.Map<IEnumerable<ReviewDto>>(reviews);

            return (reviews: reviewsDto, metaData: reviews.MetaData);
        }

        public async Task<ReviewDto> GetReviewAsync(Guid authorId, Guid bookId, Guid reviewId, bool trackChanges)
        {
            await CheckIfAuthorAndBookExist(authorId, bookId, trackChanges);

            var review = await GetReviewAndCheckIfItExist(bookId, reviewId, trackChanges);
            var reviewDto = _mapper.Map<ReviewDto>(review);

            return reviewDto;
        }

        public async Task<ReviewDto> CreateReviewForBookAsync(Guid authorId, Guid bookId, ReviewForCreationDto reviewForCreation, bool trackChanges)
        {
            await CheckIfAuthorAndBookExist(authorId, bookId, trackChanges);

            var reviewEntity = _mapper.Map<Review>(reviewForCreation);

            _repository.Review.CreateReviewForBook(bookId, reviewEntity);
            await _repository.SaveAsync();

            var reviewToReturn = _mapper.Map<ReviewDto>(reviewEntity);

            return reviewToReturn;
        }

        public async Task DeleteReviewAsync(Guid authorId, Guid bookId, Guid reviewId, bool trackChanges)
        {
            await CheckIfAuthorAndBookExist(authorId, bookId, trackChanges);
            var review = await GetReviewAndCheckIfItExist(bookId, reviewId, trackChanges);

            _repository.Review.DeleteReview(review);
            await _repository.SaveAsync();
        }

        public async Task UpdateReviewAsync(Guid authorId, Guid bookId, Guid reviewId, ReviewForUpdateDto reviewForUpdate, bool autTrackChanges, bool bookTrackChanges, bool revTrackChanges)
        {
            await CheckIfAuthorAndBookExist(authorId, bookId, autTrackChanges, bookTrackChanges);
            var review = await GetReviewAndCheckIfItExist(bookId, reviewId, revTrackChanges);

            _mapper.Map(reviewForUpdate, review);
            await _repository.SaveAsync();
        }

        public async Task<(ReviewForUpdateDto reviewToPatch, Review reviewEntity)> GetReviewForPatchAsync(Guid authorId, Guid bookId, Guid reviewId, bool autTrackChanges, bool bookTrackChanges, bool revTrackChanges)
        {
            await CheckIfAuthorAndBookExist(authorId, bookId, autTrackChanges, bookTrackChanges);
            var review = await GetReviewAndCheckIfItExist(bookId, reviewId, revTrackChanges);

            var reviewToPatch = _mapper.Map<ReviewForUpdateDto>(review);
            return (reviewToPatch, review);
        }

        public async Task SaveChangesForPatchAsync(ReviewForUpdateDto reviewToPatch, Review reviewEntity)
        {
            _mapper.Map(reviewToPatch, reviewEntity);
            await _repository.SaveAsync();
        }

        public async Task CheckIfAuthorAndBookExist(Guid authorId, Guid bookId, bool autTrackChanges, bool bookTrackChanges)
        {
            _ = await _repository.Author.GetAuthorAsync(authorId, autTrackChanges) ?? throw new AuthorNotFoundException(authorId);
            _ = await _repository.Book.GetBookAsync(authorId, bookId, bookTrackChanges) ?? throw new BookNotFoundException(bookId);
        }

        public async Task CheckIfAuthorAndBookExist(Guid authorId, Guid bookId, bool trackChanges)
        {
            _ = await _repository.Author.GetAuthorAsync(authorId, trackChanges) ?? throw new AuthorNotFoundException(authorId);
            _ = await _repository.Book.GetBookAsync(authorId, bookId, trackChanges) ?? throw new BookNotFoundException(bookId);
        }

        public async Task<Review> GetReviewAndCheckIfItExist(Guid bookId, Guid reviewId, bool trackChanges)
        {
            var review = await _repository.Review.GetReviewAsync(bookId, reviewId, trackChanges) ?? throw new ReviewNotFoundException(reviewId);
            return review;
        }
    }
}
