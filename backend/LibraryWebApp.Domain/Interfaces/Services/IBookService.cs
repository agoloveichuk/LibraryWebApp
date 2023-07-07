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
    public interface IBookService
    {
        Task<(IEnumerable<BookDto> books, MetaData metaData)> GetBooksAsync(Guid authorId, BookParameters bookParameters, bool trackChanges);
        Task<BookDto> GetBookAsync(Guid authorId, Guid id, bool trackChanges);
        Task<BookDto> CreateBookForAuthorAsync(Guid authorId, BookForCreationDto book, bool trackChanges);
        Task DeleteBookAsync(Guid authorId, Guid bookId, bool trackChanges);
        Task UpdateBookAsync(Guid authorId, Guid bookId, BookForUpdateDto bookForUpdate, bool autTrackChanges, bool bookTrackChanges);
        Task<(BookForUpdateDto bookToPatch, Book bookEntity)> GetBookForPatchAsync
            (Guid authorId, Guid bookId, bool autTrackChanges, bool bookTrackChanges);
        Task SaveChangesForPatchAsync(BookForUpdateDto bookToPatch, Book bookEntity);
    }
}
