using LibraryWebApp.API.ActionFilters;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Creations;
using LibraryWebApp.Domain.Entities.DataTransferObjects.Updating;
using LibraryWebApp.Domain.Interfaces.Services;
using LibraryWebApp.Domain.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LibraryWebApp.API.Controllers
{
    [Route("api/authors/{authorId}/books/{bookId}/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public readonly IServiceManager _service;
        public ReviewController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetReviewsForBook(Guid authorId, Guid bookId, [FromQuery] ReviewParameters reviewParameters)
        {
            var pagedResult = await _service.ReviewService.GetReviewsAsync(authorId, bookId, reviewParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.reviews);
        }

        [HttpGet("{id:guid}", Name = "GetReviewForBook")]
        public async Task<IActionResult> GetReview(Guid authorId, Guid bookId, Guid id)
        {
            var review = await _service.ReviewService.GetReviewAsync(authorId, bookId, id, trackChanges: false);
            return Ok(review);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateReviewForBook(Guid authorId, Guid bookId, [FromBody] ReviewForCreationDto review)
        {
            var reviewToReturn = await _service.ReviewService.CreateReviewForBookAsync(authorId, bookId, review, trackChanges: false);

            return CreatedAtRoute("GetReviewForBook", new { authorId, bookId, id = reviewToReturn.Id }, reviewToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteReview(Guid authorId, Guid bookId, Guid id)
        {
            await _service.ReviewService.DeleteReviewAsync(authorId, bookId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateReview(Guid authorId, Guid bookId, Guid id, [FromBody] ReviewForUpdateDto reviewForUpdate)
        {
            await _service.ReviewService.UpdateReviewAsync(authorId, bookId, id, reviewForUpdate, autTrackChanges: false, bookTrackChanges: false, revTrackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateReview(Guid authorId, Guid bookId, Guid id, [FromBody] JsonPatchDocument<ReviewForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _service.ReviewService.GetReviewForPatchAsync(authorId, bookId, id, autTrackChanges: false, bookTrackChanges: false, revTrackChanges: true);
            patchDoc.ApplyTo(result.reviewToPatch, ModelState);

            TryValidateModel(result.reviewToPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.ReviewService.SaveChangesForPatchAsync(result.reviewToPatch, result.reviewEntity);

            return NoContent();
        }
    }
}
