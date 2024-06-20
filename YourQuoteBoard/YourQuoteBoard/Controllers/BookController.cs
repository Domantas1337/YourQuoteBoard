using Microsoft.AspNetCore.Mvc;
using YourQuoteBoard.DTO.Book;
using YourQuoteBoard.Exceptions;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(IBookService _bookService) : Controller
    {
        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook([FromForm]BookAddDTO bookAddDTO)
        {
            try
            {
                BookAddDTO addedBook = await _bookService.AddBookAsync(bookAddDTO);
                return Ok(addedBook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("get-display/{id}")]
        public async Task<IActionResult> GetBookForDisplayByIdAsync(Guid id)
        {
            try
            {
                BookDisplayDTO book = await _bookService.GetBookForDisplayByIdAsync(id);
                return Ok(book);
            }catch (EntityNotFoundException ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }

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


    }
}
