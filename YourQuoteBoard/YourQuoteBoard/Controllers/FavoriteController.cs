using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController(IFavoriteService _favoriteService) : ControllerBase
    {

        [HttpPost("{quoteId}")]
        public async Task<IActionResult> AddFavoriteQuote(Guid quoteId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (userId == null)
            {
                return NotFound("User not found");
            }

            await _favoriteService.Insert(userId, quoteId); ;

            return Ok();
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetAllFavoritesForUserAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var favorites = await _favoriteService.GetFavoritesByUserId(userId);
            return Ok(favorites);
        }

        [HttpGet("ping-favorite-quote/{quoteId}")]
        public async Task<IActionResult> CheckIfQuoteIsFavoriteAsync(Guid quoteId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isFavorite = await _favoriteService.CheckIfQuoteIsFavoriteAsync(quoteId, userId);

            return Ok(isFavorite);
        }

        [HttpDelete("{quoteId}")]
        public async Task<IActionResult> RemoveFavorite(Guid quoteId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null) 
            {
                return NotFound();
            }

            try
            {
                await _favoriteService.RemoveFavorite(quoteId, userId);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
