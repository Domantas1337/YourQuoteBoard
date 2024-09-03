using Microsoft.AspNetCore.Mvc;
using YourQuoteBoard.DTO.Book;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(IBookService _bookService, IBookRatingService bookRatingService) : ControllerBase
    {
        /// <summary>
        /// Add a book
        /// </summary>
        /// <param name="bookAddDTO">New book.</param>
        /// <response code="200">Book added.</response>
        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook([FromForm] BookAddDTO bookAddDTO)
        {
            BookAddDTO addedBook = await _bookService.AddBookAsync(bookAddDTO);
            return Ok(addedBook);
        }

        /// <summary>
        /// Get a book for displaying on a page.
        /// </summary>
        /// <param name="bookId">The id of the book.</param>
        /// <response code="200">Book fetched.</response>
        [HttpGet("get-display/{bookId}")]
        public async Task<IActionResult> GetBookForDisplayByIdAsync(Guid bookId)
        {
            BookDisplayDTO book = await _bookService.GetBookForDisplayByIdAsync(bookId);
            return Ok(book);
        }

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <response code="200">Books fetched.</response>
        [HttpGet("all-books")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                List<BookDisplayDTO> booksForDisplay = await _bookService.GetAllBooksAsync();
                return Ok(booksForDisplay);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Delete the book.
        /// </summary>
        /// <param name="bookId">The id of the book.</param>
        /// <response code="200">Book deleted.</response>
        /// <response code="404">Book not found.</response>
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBookAsync(Guid bookId)
        {
            try
            {
                await _bookService.DeleteBookAsync(bookId);
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}
