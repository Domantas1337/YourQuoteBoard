using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Filters;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookRatingController(IBookRatingService _ratingService, IBookService _bookService) : ControllerBase
    {
        /// <summary>
        /// Update book rating
        /// </summary>
        /// <param name="bookRatingDTO">A DTO with an existing book rating ID</param>
        /// <response code="200">Book rating updated.</response>
        [HttpPut("update-book-rating")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> UpdateBookRatingAsync(BookRatingUpdateDTO bookRatingDTO)
        {
            var userId = HttpContext.Items["UserId"] as string;

            BookRatingUpdateDTO updatedBookRating = await _ratingService.UpdateBookRatingAsync(bookRatingDTO, userId);
                        
            return Ok(updatedBookRating);
        }


        /// <summary>
        /// Add book rating
        /// </summary>
        /// <param name="bookRating">A DTO with new book rating data</param>
        /// <response code="200">Book rating added.</response>
        /// <response code="404">User not foind</response>
        [HttpPost("book-rating")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> AddBookRating(BookRatingCreateDTO bookRating)
        {
            var userId = HttpContext.Items["UserId"] as string;

            Guid addedRatingId = await _ratingService.AddBookRatingAsync(bookRating, userId);
            return Ok(addedRatingId);
        }

        /// <summary>
        /// Gets the rating a user gave to a book 
        /// </summary>
        /// <param name="bookId">The Id of the book</param>
        /// <response code="200">Book rating returned.</response>
        /// <response code="404">User not foind</response>
        [HttpGet("book-rating-by-user/{bookId}")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> GetBookRatingByUser(Guid bookId)
        {
            var userId = HttpContext.Items["UserId"] as string;

            BookRatingForDirectUserInteractionDTO? bookRating = await _ratingService.GetBookRatingByUserAsync(userId, bookId);

            return Ok(bookRating);
        }

        /// <summary>
        /// Gets all the ratings of a book
        /// </summary>
        /// <param name="bookId">The Id of the book</param>
        /// <response code="200">Book ratings returned.</response>
        [HttpGet("book-ratings/{bookId}")]
        public async Task<IActionResult> GetBookRatingsAsync(Guid bookId)
        {
            List<BookRatingDisplayDTO> bookRatings = await _ratingService.GetRatingsForBookAsync(bookId);
            return Ok(bookRatings);
        }

        /// <summary>
        /// Gets all the ratings of all book
        /// </summary>
        /// <response code="200">All book ratings returned.</response>
        [HttpGet("all-book-ratings")]
        public async Task<IActionResult> GetAllBookRatingsAsync()
        {
            List<BookRatingDisplayDTO> bookRatings = await _ratingService.GetAllBookRatingsAsync();
            return Ok(bookRatings);
        }

    }
}
