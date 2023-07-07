using LibraryWebApp.API.ActionFilters;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Creations;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Updating;
using LibraryWebApp.Domain.Entities.Models;
using LibraryWebApp.Domain.Interfaces.Services;
using LibraryWebApp.Domain.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace LibraryWebApp.API.Controllers
{
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IServiceManager _service;
        public BookController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetBooksForAuthor(Guid authorId, [FromQuery] BookParameters bookParameters)
        {
            var pagedResult = await _service.BookService.GetBooksAsync(authorId, bookParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.books);
        }

        [HttpGet("{id:guid}", Name = "GetBookForAuthor")]
        public async Task<IActionResult> GetBook(Guid authorId, Guid id) 
        {
            var book = await _service.BookService.GetBookAsync(authorId, id, trackChanges: false);
            return Ok(book);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateBookForAuthor(Guid authorId, [FromBody] BookForCreationDto book)
        {
            var bookToReturn = await _service.BookService.CreateBookForAuthorAsync(authorId, book, trackChanges: false);

            return CreatedAtRoute("GetBookForAuthor", new { authorId, id = bookToReturn.Id }, bookToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBook(Guid authorId, Guid id)
        {
            await _service.BookService.DeleteBookAsync(authorId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateBook(Guid authorId, Guid id, [FromBody] BookForUpdateDto bookForUpdate)
        {
            await _service.BookService.UpdateBookAsync(authorId, id, bookForUpdate, autTrackChanges: false, bookTrackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateBook(Guid authorId, Guid id, [FromBody] JsonPatchDocument<BookForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _service.BookService.GetBookForPatchAsync(authorId, id, autTrackChanges: false, bookTrackChanges: true);
            patchDoc.ApplyTo(result.bookToPatch, ModelState);

            TryValidateModel(result.bookToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.BookService.SaveChangesForPatchAsync(result.bookToPatch, result.bookEntity);

            return NoContent();
        }
    }
}
