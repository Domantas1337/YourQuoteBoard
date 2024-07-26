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

        [HttpPost]
        public async Task<IActionResult> AddFavoriteQuote(Guid quoteId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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
    }
}
