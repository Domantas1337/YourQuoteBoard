using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController(IQuoteService _quoteService) : ControllerBase
    {

        [HttpGet("is-quote-users/{quoteId}")]
        public async Task<IActionResult> GetQuoteOwnershipValidation(Guid quoteId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound("User not found");
            }

            bool isQuoteUsers = await _quoteService.CheckIfUserOwnsQuoteAsync(quoteId, userId);

            return Ok(isQuoteUsers);
        }

        [Authorize]
        [HttpGet("favorite-quotes")]
        public async Task<IActionResult> GetFavoriteQuotesAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound("User not found");
            }

            var favoriteQuotes = await _quoteService.GetAllPersonalQuotesAsync(userId);

            return Ok(favoriteQuotes);
        }


        [Authorize]
        [HttpPost("add-quote")]
        public async Task<IActionResult> AddQuoteAsync(QuoteAddDTO quoteAddDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound("User not found");
            }

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

            if (userId == null)
            {
                return NotFound("User not found");
            }

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

        [HttpDelete("delete-quotes")]
        public async Task<IActionResult> DeleteQuoteCollectionAsync(ICollection<Guid> quoteIds)
        {
            try
            {
                await _quoteService.DeleteQuoteCollectionAsync(quoteIds);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("delete-quote/{quoteId}")]
        public async Task<IActionResult> DeleteQuoteAsync(Guid quoteId)
        {
            try
            {
                await _quoteService.DeleteQuoteAsync(quoteId);
            }catch (NullReferenceException ex) 
            {
                return NotFound(ex.Message);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

    }
}
