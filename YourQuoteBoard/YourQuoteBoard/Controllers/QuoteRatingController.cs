using Microsoft.AspNetCore.Mvc;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Filters;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteRatingController : BaseController
    {
        private readonly IQuoteRatingService _ratingService;

        public QuoteRatingController(IQuoteRatingService quoteRatingService)
        {
            _ratingService = quoteRatingService;
        }

        /// <summary>
        /// Updates the whole quote rating, including overall rating, specific rating.
        /// </summary>
        /// <param name="quoteRatingDTO">DTO with an existing quote rating ID</param>
        /// <response code="200">Quote rating updated.</response>
        [HttpPut("update-quote-rating")]
        public async Task<IActionResult> UpdateQuoteRatingAsync(QuoteRatingUpdateDTO quoteRatingDTO)
        {
            QuoteRatingUpdateDTO? updatedquoteRating = await _ratingService.UpdateQuoteRatingAsync(quoteRatingDTO);

            if (updatedquoteRating == null)
            {
                return BadRequest();
            }
            return Ok(updatedquoteRating);
        }

        /// <summary>
        /// Adds a quote rating
        /// </summary>
        /// <param name="quoteRating">DTO for crating a quote rating</param>
        /// <response code="200">Quote rating added.</response>
        /// <response code="404">User not found.</response>
        /// <response code="400">The request is formed incorrectly</response>
        [HttpPost("quote-rating")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> AddQuoteRating(QuoteRatingCreateDTO quoteRating)
        {
            var userId = HttpContext.Items["UserId"] as string;
            bool isAdded = await _ratingService.AddQuoteRatingAsync(quoteRating, userId);

            if (!isAdded)
            {
                return BadRequest();
            }
            return Ok();
        }

        /// <summary>
        /// Get quote rating by user
        /// </summary>
        /// <param name="quoteId"> The id of the quote for which the ratings are fetched</param>
        /// <response code="200">Quote ratings returned.</response>
        /// <response code="404">User not found.</response>
        [HttpGet("quote-rating-by-user/{quoteId}")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> GetQuoteRatingByUser(Guid quoteId)
        {
            var userId = HttpContext.Items["UserId"] as string;

            QuoteRatingForDirectUserInteractionDTO? quoteRating = await _ratingService.GetQuoteRatingByUserAsync(userId, quoteId);

            return Ok(quoteRating);
        }

        /// <summary>
        /// Gets all ratings for a specific quote.
        /// </summary>
        /// <param name="quoteId">The id of the quote.</param>
        /// <response code="200">Quote ratings fetched.</response>
        [HttpGet("quote-ratings/{quoteId}")]
        public async Task<IActionResult> GetQuoteRatingsAsync(Guid quoteId)
        {
            List<QuoteRatingDisplayDTO> quoteRatings = await _ratingService.GetRatingsForQuoteAsync(quoteId);
            return Ok(quoteRatings);
        }

        /// <summary>
        /// Gets all quote ratings.
        /// </summary>
        /// <response code="200">Quote ratings fetched.</response>
        [HttpGet("all-quote-ratings")]
        public async Task<IActionResult> GetAllQuoteRatingsAsync()
        {
            List<QuoteRatingDisplayDTO> quoteRatings = await _ratingService.GetAllQuoteRatingsAsync();
            return Ok(quoteRatings);
        }

        /// <summary>
        /// Gets specific ratings given by that user for a quote
        /// </summary>
        /// <param name="quoteRatingId">The ID of the quote rating.</param>
        /// <response code="200">Specific ratings a user gave to a quote returned.</response>
        /// <response code="400">User not found.</response>
        [HttpGet("specific-ratings/{quoteRatingId}")]
        public async Task<IActionResult> GetSpecificRatingsByUserAsync(Guid quoteRatingId)
        {
            ICollection<QuoteSpecificRating> specificRatings = await _ratingService.GetSpecificRatingsByRatingId(quoteRatingId);
            return Ok(specificRatings);
        }
    }
}
