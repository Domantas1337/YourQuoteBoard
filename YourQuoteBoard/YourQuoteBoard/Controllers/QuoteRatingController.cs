using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteRatingController(IQuoteRatingService _ratingService) : Controller
    {

        [HttpPut("update-quote-rating")]
        public async Task<IActionResult> UpdateQuoteRatingAsync(QuoteRatingUpdateDTO quoteRatingDTO)
        {
            QuoteRatingUpdateDTO updatedquoteRating = await _ratingService.UpdateQuoteRatingAsync(quoteRatingDTO);

            return Ok(updatedquoteRating);
        }

        [HttpPost("quote-rating")]
        public async Task<IActionResult> AddQuoteRating(QuoteRatingCreateDTO quoteRating)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest("User does not exist");
            }

            QuoteRatingCreateDTO addedRating = await _ratingService.AddQuoteRatingAsync(quoteRating, userId);
            return Ok(addedRating);
        }

        [HttpGet("quote-rating-by-user/{quoteId}")]
        public async Task<IActionResult> GetQuoteRatingByUser(Guid quoteId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest("User does not exist");
            }

            QuoteRatingForDirectUserInteractionDTO? quoteRating = await _ratingService.GetQuoteRatingByUserAsync(userId, quoteId);

            return Ok(quoteRating);
        }

        [HttpGet("quote-ratings/{quoteId}")]
        public async Task<IActionResult> GetQuoteRatingsAsync(Guid quoteId)
        {
            List<QuoteRatingDisplayDTO> quoteRatings = await _ratingService.GetRatingsForQuoteAsync(quoteId);
            return Ok(quoteRatings);
        }

        [HttpGet("all-quote-ratings")]
        public async Task<IActionResult> GetAllQuoteRatingsAsync()
        {
            List<QuoteRatingDisplayDTO> quoteRatings = await _ratingService.GetAllQuoteRatingsAsync();
            return Ok(quoteRatings);
        }
    }
}
