using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController(IRatingService _ratingService) : Controller
    {
        [HttpPost("book-rating")]
        public async Task<IActionResult> AddBookRating(BookRatingDTO bookRating)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest("User does not exist");
            }

            BookRatingDTO addedRating = await _ratingService.AddBookRating(bookRating, userId);
            return Ok(addedRating);
        }

        [HttpGet("book-ratings/{bookId}")]
        public async Task<IActionResult> GetBookRatingsAsync(Guid bookId)
        {
            List<BookRatingDTO> bookRatings = await _ratingService.GetRatingsForBookAsync(bookId);
            return Ok(bookRatings);
        }

        [HttpGet("all-book-ratings")]
        public async Task<IActionResult> GetAllBookRatingsAsync()
        {
            List<BookRatingDTO> bookRatings = await _ratingService.GetAllBookRatingsAsync();
            return Ok(bookRatings);
        }

    }
}
