using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.Filters;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController(IQuoteService _quoteService) : ControllerBase
    {
        /// <summary>
        /// Checks if the quote was added by the user.
        /// </summary>
        /// <param name="quoteId">Id of the quote.</param>
        /// <response code="200">Quote ownership checked.</response>
        /// <response code="404">User not foind</response>
        [HttpGet("is-quote-users/{quoteId}")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> GetQuoteOwnershipValidation(Guid quoteId)
        {
            var userId = HttpContext.Items["UserId"] as string;
            bool isQuoteUsers = await _quoteService.CheckIfUserOwnsQuoteAsync(quoteId, userId);

            return Ok(isQuoteUsers);
        }

        /// <summary>
        /// Gets all the favorite quotes of a user .
        /// </summary>
        /// <response code="200">Favorite quotes fetched.</response>
        /// <response code="404">User not foind</response>
        [Authorize]
        [HttpGet("favorite-quotes")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> GetFavoriteQuotesAsync()
        {
            var userId = HttpContext.Items["UserId"] as string;
            var favoriteQuotes = await _quoteService.GetAllPersonalQuotesAsync(userId);

            return Ok(favoriteQuotes);
        }

        /// <summary>
        /// Add a quote.
        /// </summary>
        /// <param name="quoteAddDTO">DTO to add a new quote.</param>
        /// <response code="200">Quote added.</response>
        /// <response code="404">User not foind</response>
        [Authorize]
        [HttpPost("add-quote")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> AddQuoteAsync(QuoteAddDTO quoteAddDTO)
        {
            var userId = HttpContext.Items["UserId"] as string;

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

        /// <summary>
        /// Gets all quotes added by a user .
        /// </summary>
        /// <response code="200">Quotes fetched.</response>
        /// <response code="404">User not foind</response>
        [Authorize]
        [HttpGet("all-personal-quotes")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> GetAllPersonalQuotesAsync()
        {
            var userId = HttpContext.Items["UserId"] as string;
            List<QuoteDisplayDTO> quotes = await _quoteService.GetAllPersonalQuotesAsync(userId);

            return Ok(quotes);
        }

        /// <summary>
        /// Gets all the quotes.
        /// </summary>
        /// <response code="200">Quotes fetched.</response>
        [HttpGet("all-quotes")]
        public async Task<IActionResult> GetAllQuotes()
        {
            var quotes = await _quoteService.GetAllQuotesAsync();
            return Ok(quotes);
        }

        /// <summary>
        /// Get quotes that are in the specified book.
        /// </summary>
        /// <param name="bookId">The Id of the book.</param>
        /// <response code="200">Quotes fetched.</response>
        [HttpGet("quotes-by-book/{bookId}")]
        public async Task<IActionResult> GetQuotesByBookId(Guid bookId)
        {
            List<QuoteDisplayDTO> quotes = await _quoteService.GetQuotesByBookIdAsync(bookId);
            return Ok(quotes);
        }

        /// <summary>
        /// Get quotes that are in the specified book.
        /// </summary>
        /// <param name="quoteId">The Id of the quote.</param>
        /// <response code="200">Quotes fetched.</response>
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

        /// <summary>
        /// Deletes multiple quotes.
        /// </summary>
        /// <param name="quoteIds">A collection of quote Ids.</param>
        /// <response code="200">Quotes deleted.</response>
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

        /// <summary>
        /// Deletes a single quote
        /// </summary>
        /// <param name="quoteId">The Id of the quote.</param>
        /// <response code="200">Quote deleted.</response>
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
