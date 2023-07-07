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
    public interface IAuthorService
    {
        Task<(IEnumerable<AuthorDto> authors, MetaData metaData)> GetAuthorsAsync(AuthorParameters authorParameters, bool trackChanges);
        Task<AuthorDto> GetAuthorAsync(Guid authorId, bool trackChanges);
        Task<IEnumerable<AuthorDto>> GetAuthorsByIdsAsync(IEnumerable<Guid> authorsIds,  bool trackChanges);
        Task<(IEnumerable<AuthorDto> authors, string authorsIds)> CreateAuthorsByIdsAsync(IEnumerable<AuthorForCreationDto> authorsCollection);
        Task<AuthorDto> CreateAuthorAsync(AuthorForCreationDto author);
        Task DeleteAuthorAsync(Guid authorId, bool trackChanges);
        Task UpdateAuthorAsync(Guid authorId, AuthorForUpdateDto auuthorForUpdate, bool trackChanges);
        Task<(AuthorForUpdateDto authorToPatch, Author authorEntity)> GetAuthorForPatchAsync(Guid authorId, bool trackChanges);
        Task SaveChangesForPatchAsync(AuthorForUpdateDto authorToPatch, Author authorEntity);
    }
}
