using Microsoft.AspNetCore.Mvc;
using YourQuoteBoard.DTO.Book;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(IBookService _bookService) : Controller
    {
        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook(BookAddDTO bookAddDTO)
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
