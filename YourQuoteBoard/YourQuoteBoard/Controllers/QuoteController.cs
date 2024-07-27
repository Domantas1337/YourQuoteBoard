using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController(IQuoteService _quoteService) : Controller
    {

        [Authorize]
        [HttpGet("favorite-quotes")]
        public async Task<IActionResult> GetFavoriteQuotesAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favoriteQuotes = await _quoteService.GetAllPersonalQuotesAsync(userId);


            return Ok(favoriteQuotes);
        }


        [Authorize]
        [HttpPost("add-quote")]
        public async Task<IActionResult> AddQuoteAsync(QuoteAddDTO quoteAddDTO)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                QuoteAddDTO addedQuote = await _quoteService.AddQuoteAsync(quoteAddDTO, userId);
                return Ok(addedQuote);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [Authorize]
        [HttpGet("all-personal-quotes")]
        public async Task<IActionResult> GetAllPersonalQuotesAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<QuoteDisplayDTO> quotes = await _quoteService.GetAllPersonalQuotesAsync(userId);

            return Ok(quotes);
        }

        [HttpGet("all-quotes")]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _quoteService.GetAllQuotesAsync();
            return Ok(quotes);
        }

        [HttpGet("quotes-by-book/{bookId}")]
        public async Task<IActionResult> GetQuotesByBookId(Guid bookId)
        {
            List<QuoteDisplayDTO> quotes = await _quoteService.GetQuotesByBookIdAsync(bookId);
            return Ok(quotes);
        }

        [HttpGet("quote/{quoteId}")]
        public async Task<IActionResult> GetQuoteForDesignatedPage(Guid quoteId)
        {
            QuoteFullDisplayDTO? quote = await _quoteService.GetQuoteForQuoteDedicatedPageAsync(quoteId);
            
            if (quote == null)
            {
                return BadRequest("No such quote was found");
            }
            
            return Ok(quote);
        }
    }
}
