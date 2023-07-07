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
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebApp.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AuthorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<AuthorDto> authors, MetaData metaData)> GetAuthorsAsync(AuthorParameters authorParameters, bool trackChanges)
        {
            var authors = await _repository.Author.GetAllAuthorsAsync(authorParameters, trackChanges);
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return (authors: authorsDto, metaData: authors.MetaData);
        }

        public async Task<AuthorDto> GetAuthorAsync(Guid authorId, bool trackChanges)
        {
            var author = await GetAuthorAndCheckIfItExist(authorId, trackChanges);
            var authorDto = _mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthorsByIdsAsync(IEnumerable<Guid> authorsIds, bool trackChanges)
        {
            if (authorsIds is null)
                throw new IdParametersBadRequestException();

            var authors = await _repository.Author.GetAuthorsByIdsAsync(authorsIds, trackChanges);
            if (authorsIds.Count() !=  authors.Count())
                throw new CollectionByIdsBadRequestException();

            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return authorsDto;
        }

        public async Task<AuthorDto> CreateAuthorAsync(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);

            _repository.Author.CreateAuthor(authorEntity);
            await _repository.SaveAsync();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

            return authorToReturn;
        }

        public async Task<(IEnumerable<AuthorDto> authors, string authorsIds)> CreateAuthorsByIdsAsync(IEnumerable<AuthorForCreationDto> authorsCollection)
        {
            if (authorsCollection is null)
                throw new AuthorCollectionBadRequest();

            var authorsEntities = _mapper.Map<IEnumerable<Author>>(authorsCollection);

            foreach (var author in authorsEntities)
            {
                _repository.Author.CreateAuthor(author);
            }
            await _repository.SaveAsync();

            var authorsToReturn = _mapper.Map<IEnumerable<AuthorDto>>(authorsEntities);
            var authorsIds = string.Join(",", authorsToReturn.Select(c => c.Id));

            return (authors: authorsToReturn, authorsIds : authorsIds);
        }

        public async Task DeleteAuthorAsync(Guid authorId, bool trackChanges)
        {
            var author = await GetAuthorAndCheckIfItExist(authorId, trackChanges);

            _repository.Author.DeleteAuthor(author);
            await _repository.SaveAsync();
        }

        public async Task UpdateAuthorAsync(Guid authorId, AuthorForUpdateDto auuthorForUpdate, bool trackChanges)
        {
            var author = await GetAuthorAndCheckIfItExist(authorId, trackChanges);

            _mapper.Map(auuthorForUpdate, author);
            await _repository.SaveAsync();
        }

        public async Task<(AuthorForUpdateDto authorToPatch, Author authorEntity)> GetAuthorForPatchAsync(Guid authorId, bool trackChanges)
        {

            var author = await GetAuthorAndCheckIfItExist(authorId, trackChanges);
            var authorToPatch = _mapper.Map<AuthorForUpdateDto>(author);
            return (authorToPatch, author);
        }

        public async Task SaveChangesForPatchAsync(AuthorForUpdateDto authorToPatch, Author authorEntity)
        {
            _mapper.Map(authorToPatch, authorEntity);
            await _repository.SaveAsync();
        }

        public async Task<Author> GetAuthorAndCheckIfItExist(Guid authorId, bool trackChanges)
        {
            var author = await _repository.Author.GetAuthorAsync(authorId, trackChanges) ?? throw new AuthorNotFoundException(authorId);
            return author;
        }
    }
}
