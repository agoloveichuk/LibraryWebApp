using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain.Interfaces.Repository
{
    public interface IAuthorRepository
    {
        Task<PagedList<Author>> GetAllAuthorsAsync(AuthorParameters authorParameters, bool trackChanges);
        Task<Author> GetAuthorAsync(Guid authorId, bool trackChanges);
        Task<IEnumerable<Author>> GetAuthorsByIdsAsync(IEnumerable<Guid> authorIds, bool trackChanges);
        void CreateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
