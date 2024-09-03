using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourQuoteBoard.Filters;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController(IFavoriteService _favoriteService) : ControllerBase
    {
        /// <summary>
        /// Add a quote to user's favorites.
        /// </summary>
        /// <param name="quoteId">The Id of the quote.</param>
        /// <response code="200">Quote added to favorites.</response>
        /// <response code="404">User not foind</response>
        [HttpPost("{quoteId}")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> AddFavoriteQuote(Guid quoteId)
        {
            var userId = HttpContext.Items["UserId"] as string;
            await _favoriteService.Insert(userId, quoteId); ;

            return Ok();
        }

        /// <summary>
        /// Gets all favorite quotes of the user.
        /// </summary>
        /// <response code="200">Favorite quotes fetched.</response>
        /// <response code="404">User not foind</response>
        [HttpGet("user")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> GetAllFavoritesForUserAsync()
        {
            var userId = HttpContext.Items["UserId"] as string;
            var favorites = await _favoriteService.GetFavoritesByUserId(userId);
            
            return Ok(favorites);
        }

        /// <summary>
        /// Pings if a quote is user's favorites.
        /// </summary>
        /// <param name="quoteId">The Id of the quote.</param>
        /// <response code="200">The quote was pinged.</response>
        /// <response code="404">User not foind</response>
        [HttpGet("ping-favorite-quote/{quoteId}")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> CheckIfQuoteIsFavoriteAsync(Guid quoteId)
        {
            var userId = HttpContext.Items["UserId"] as string;
            var isFavorite = await _favoriteService.CheckIfQuoteIsFavoriteAsync(quoteId, userId);
            return Ok(isFavorite);
        }

        /// <summary>
        /// Rempves a quote from user's favorites.
        /// </summary>
        /// <param name="quoteId">The Id of the quote that needs to be removed from user's favorites.</param>
        /// <response code="200">The quote was pinged.</response>
        /// <response code="404">User not foind</response>
        [HttpDelete("{quoteId}")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> RemoveFavorite(Guid quoteId)
        {
            var userId = HttpContext.Items["UserId"] as string;

            await _favoriteService.RemoveFavorite(quoteId, userId);
            return Ok();
        }
    }
}
