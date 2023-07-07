using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.Interfaces.Repository;
using LibraryWebApp.Domain.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryWebApp.Infrastructure.Data.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<PagedList<Author>> GetAllAuthorsAsync(AuthorParameters authorParameters, bool trackChanges)
        {
            var authors = await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

            return PagedList<Author>.ToPagedList(authors, authorParameters.PageNumber, authorParameters.PageSize);
        }
            

        public async Task<Author> GetAuthorAsync(Guid authorId, bool trackChanges) =>
            await FindByCondition(a => a.Id.Equals(authorId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Author>> GetAuthorsByIdsAsync(IEnumerable<Guid> authorIds, bool trackChanges) =>
            await FindByCondition(a => authorIds.Contains(a.Id), trackChanges)
            .ToListAsync();

        public void CreateAuthor(Author author) => Create(author);
        public void DeleteAuthor(Author author) => Delete(author);
    }
}
