using Microsoft.AspNetCore.Mvc;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController(IQuoteService _quoteService) : Controller
    {

        [HttpPost("add-quote")]
        public async Task<IActionResult> AddQuoteAsync(QuoteAddDTO quoteAddDTO)
        {
            try
            {
                QuoteAddDTO addedQuote = await _quoteService.AddQuoteAsync(quoteAddDTO);
                return Ok(addedQuote);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("all-quotes")]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _quoteService.GetAllQuotesAsync();
            return Ok(quotes);
        }
    }
}
