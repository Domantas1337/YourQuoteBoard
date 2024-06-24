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
        [HttpPut("update-book-rating")]
        public async Task<IActionResult> UpdateBookRatingAsync(BookRatingUpdateDTO bookRatingDTO)
        {
            BookRatingUpdateDTO updatedBookRating = await _ratingService.UpdateBookRatingAsync(bookRatingDTO);
            return Ok(updatedBookRating);
        }

        [HttpPost("book-rating")]
        public async Task<IActionResult> AddBookRating(BookRatingDTO bookRating)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest("User does not exist");
            }

            BookRatingUpdateDTO addedRating = await _ratingService.AddBookRatingAsync(bookRating, userId);
            return Ok(addedRating);
        }

        [HttpGet("book-rating-by-user/{bookId}")]
        public async Task<IActionResult> GetBookRatingByUser(Guid bookId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest("User does not exist");
            }

            BookRatingUpdateDTO? bookRating = await _ratingService.GetBookRatingByUserAsync(userId, bookId);

            return Ok(bookRating);
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
