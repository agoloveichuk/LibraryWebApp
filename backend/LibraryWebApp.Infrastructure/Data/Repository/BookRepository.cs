using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.Interfaces.Repository;
using LibraryWebApp.Domain.RequestFeatures;
using LibraryWebApp.Infrastructure.Data.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.Infrastructure.Data.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<PagedList<Book>> GetBooksAsync(Guid authorId, BookParameters bookParameters, bool trackChanges)
        {
            var books = await FindByCondition(b => b.AuthorId.Equals(authorId), trackChanges)
            .FilterBooks(bookParameters.MinRating, bookParameters.MaxRating)
            .Search(bookParameters.SearchTerm)
            .OrderBy(b => b.Title)
            .ToListAsync();

            return PagedList<Book>.ToPagedList(books, bookParameters.PageNumber, bookParameters.PageSize);
        }

        public async Task<Book> GetBookAsync(Guid authorId, Guid id, bool trackChanges) =>
            await FindByCondition(b => b.AuthorId.Equals(authorId) && b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateBookForAuthor(Guid authorId, Book book)
        {
            book.AuthorId = authorId;
            Create(book);
        }

        public void DeleteBook(Book book) => Delete(book);
    }
}
