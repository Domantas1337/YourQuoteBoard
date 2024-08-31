using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity.Quotes;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IQuoteRatingService
    {
        public Task<ICollection<QuoteSpecificRating>> GetSpecificRatingsByRatingId(Guid quoteRatingId);
        public Task<QuoteRatingUpdateDTO> UpdateQuoteRatingAsync(QuoteRatingUpdateDTO quoteRatingDTO);
        public Task<QuoteRatingForDirectUserInteractionDTO?> GetQuoteRatingByUserAsync(string userId, Guid quoteId);
        public Task AddQuoteRatingAsync(QuoteRatingCreateDTO rating, string userId);
        public Task<List<QuoteRatingDisplayDTO>> GetAllQuoteRatingsAsync();
        public Task<List<QuoteRatingDisplayDTO>> GetRatingsForQuoteAsync(Guid quoteId);
    }
}
