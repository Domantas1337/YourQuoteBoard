using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookRatingController(IBookRatingService _ratingService, IBookService _bookService) : Controller
    {
        [HttpPut("update-book-rating")]
        public async Task<IActionResult> UpdateBookRatingAsync(BookRatingForUpdateDTO bookRatingDTO)
        {
            BookRatingForUpdateDTO updatedBookRating = await _ratingService.UpdateBookRatingAsync(bookRatingDTO);
                        
            return Ok(updatedBookRating);
        }

        [HttpPost("book-rating")]
        public async Task<IActionResult> AddBookRating(BookRatingCreateDTO bookRating)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest("User does not exist");
            }

            BookRatingCreateDTO addedRating = await _ratingService.AddBookRatingAsync(bookRating, userId);
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

            BookRatingForDirectUserInteractionDTO? bookRating = await _ratingService.GetBookRatingByUserAsync(userId, bookId);

            return Ok(bookRating);
        }

        [HttpGet("book-ratings/{bookId}")]
        public async Task<IActionResult> GetBookRatingsAsync(Guid bookId)
        {
            List<BookRatingDisplayDTO> bookRatings = await _ratingService.GetRatingsForBookAsync(bookId);
            return Ok(bookRatings);
        }

        [HttpGet("all-book-ratings")]
        public async Task<IActionResult> GetAllBookRatingsAsync()
        {
            List<BookRatingDisplayDTO> bookRatings = await _ratingService.GetAllBookRatingsAsync();
            return Ok(bookRatings);
        }

    }
}
