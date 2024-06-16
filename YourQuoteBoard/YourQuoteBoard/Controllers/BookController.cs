using Microsoft.AspNetCore.Mvc;
using YourQuoteBoard.DTO.Book;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {

        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook(BookAddDTO bookAddDTO)
        {
            return View();
        }

        [HttpGet("all-books")]
        public async Task<IActionResult> GetAllBooks(BookAddDTO bookAddDTO)
        {
            return View();
        }


    }
}
