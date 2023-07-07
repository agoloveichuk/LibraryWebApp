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

namespace LibraryWebApp.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public BookService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetBooksAsync(Guid authorId, BookParameters bookParameters, bool trackChanges)
        {
            if (!bookParameters.ValidRatingRange)
                throw new MaxRatingRangeBadRequestException();

            await CheckIfAuthorExist(authorId, trackChanges);
            var books = await _repository.Book.GetBooksAsync(authorId, bookParameters, trackChanges);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            return (books: booksDto, metaData: books.MetaData);
        }

        public async Task<BookDto> GetBookAsync(Guid authorId, Guid bookId, bool trackChanges) 
        {
            await CheckIfAuthorExist(authorId, trackChanges);
            var book = await GetBookAndCheckIfItExist(authorId, bookId, trackChanges);
            var bookDto = _mapper.Map<BookDto>(book);

            return bookDto;
        }

        public async Task<BookDto> CreateBookForAuthorAsync(Guid authorId, BookForCreationDto bookForCreation, bool trackChanges)
        {
            await CheckIfAuthorExist(authorId, trackChanges);

            var bookEntity = _mapper.Map<Book>(bookForCreation);

            _repository.Book.CreateBookForAuthor(authorId, bookEntity);
            await _repository.SaveAsync();

            var bookToReturn = _mapper.Map<BookDto>(bookEntity);

            return bookToReturn;
        }

        public async Task DeleteBookAsync(Guid authorId, Guid bookId, bool trackChanges)
        {
            await CheckIfAuthorExist(authorId, trackChanges);
            var book = await GetBookAndCheckIfItExist(authorId, bookId, trackChanges);

            _repository.Book.DeleteBook(book);
            await _repository.SaveAsync();
        }

        public async Task UpdateBookAsync(Guid authorId, Guid bookId, BookForUpdateDto bookForUpdate, bool autTrackChanges, bool bookTrackChanges)
        {
            await CheckIfAuthorExist(authorId, autTrackChanges);
            var book = await GetBookAndCheckIfItExist(authorId, bookId, bookTrackChanges);

            _mapper.Map(bookForUpdate, book);
            await _repository.SaveAsync();
        }

        public async Task<(BookForUpdateDto bookToPatch, Book bookEntity)> GetBookForPatchAsync(Guid authorId, Guid bookId, bool autTrackChanges, bool bookTrackChanges)
        {
            await CheckIfAuthorExist(authorId, autTrackChanges);
            var book = await GetBookAndCheckIfItExist(authorId, bookId, bookTrackChanges);

            var bookToPatch = _mapper.Map<BookForUpdateDto>(book);
            return (bookToPatch, book);
        }

        public async Task SaveChangesForPatchAsync(BookForUpdateDto bookToPatch, Book bookEntity)
        {
            _mapper.Map(bookToPatch, bookEntity);
            await _repository.SaveAsync();
        }

        public async Task CheckIfAuthorExist(Guid authorId, bool autTrackChanges)
        {
            _ = await _repository.Author.GetAuthorAsync(authorId, autTrackChanges) ?? throw new AuthorNotFoundException(authorId);
        }

        public async Task<Book> GetBookAndCheckIfItExist(Guid authorId, Guid bookId, bool bookTrackChanges)
        {
            var book = await _repository.Book.GetBookAsync(authorId, bookId, bookTrackChanges) ?? throw new BookNotFoundException(bookId);
            return book;
        }
    }
}
