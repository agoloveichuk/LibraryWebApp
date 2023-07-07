using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Interfaces.Repository
{
    public interface IBookRepository
    {
        Task<PagedList<Book>> GetBooksAsync(Guid authorId, BookParameters bookParameters, bool trackChanges);
        Task<Book> GetBookAsync(Guid authorId, Guid id, bool trackChanges);
        void CreateBookForAuthor(Guid authorId, Book book);
        void DeleteBook(Book boook);
    }
}
