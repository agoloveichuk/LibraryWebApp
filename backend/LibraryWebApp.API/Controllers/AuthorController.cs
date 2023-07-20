using LibraryWebApp.API.ActionFilters;
using LibraryWebApp.API.ModelBinders;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Creations;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Updating;
using LibraryWebApp.Domain.Interfaces.Services;
using LibraryWebApp.Domain.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LibraryWebApp.API.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthorController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAuthors([FromQuery] AuthorParameters authorParameters)
        {
            var pagedResult = await _service.AuthorService.GetAuthorsAsync(authorParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.authors);
        }

        [HttpGet("{id:guid}", Name = "AuthorById")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var author = await _service.AuthorService.GetAuthorAsync(id, trackChanges: false);
            return Ok(author);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto author)
        {
            var createdAuthor = await _service.AuthorService.CreateAuthorAsync(author);

            return CreatedAtRoute("AuthorById", new { id = createdAuthor.Id }, createdAuthor);
        }

        [HttpGet("collection/({ids})", Name = "AuthorsCollection")]
        public async Task<IActionResult> GetAuthorsByIds([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var authors = await _service.AuthorService.GetAuthorsByIdsAsync(ids, trackChanges: false);

            return Ok(authors);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateAuthorsByIds([FromBody] IEnumerable<AuthorForCreationDto> authorsCollection)
        {
            var result = await _service.AuthorService.CreateAuthorsByIdsAsync(authorsCollection);

            return CreatedAtRoute("AuthorsCollection", new { ids = result.authorsIds }, result.authors);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            await _service.AuthorService.DeleteAuthorAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] AuthorForUpdateDto authorForUpdate)
        {
            await _service.AuthorService.UpdateAuthorAsync(id, authorForUpdate, trackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateAuthor(Guid id, [FromBody] JsonPatchDocument<AuthorForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");
            var result = await _service.AuthorService.GetAuthorForPatchAsync(id, trackChanges: true);
            patchDoc.ApplyTo(result.authorToPatch, ModelState);

            TryValidateModel(result.authorToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.AuthorService.SaveChangesForPatchAsync(result.authorToPatch, result.authorEntity);

            return NoContent();
        }
    }
}
