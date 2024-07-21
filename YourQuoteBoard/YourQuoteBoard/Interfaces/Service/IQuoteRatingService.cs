using YourQuoteBoard.DTO.Rating.Quote;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IQuoteRatingService
    {
        public Task<QuoteRatingUpdateDTO> UpdateQuoteRatingAsync(QuoteRatingUpdateDTO quoteRatingDTO);
        public Task<QuoteRatingForDirectUserInteractionDTO?> GetQuoteRatingByUserAsync(string userId, Guid quoteId);
        public Task<QuoteRatingCreateDTO> AddQuoteRatingAsync(QuoteRatingCreateDTO rating, string userId);
        public Task<List<QuoteRatingDisplayDTO>> GetAllQuoteRatingsAsync();
        public Task<List<QuoteRatingDisplayDTO>> GetRatingsForQuoteAsync(Guid quoteId);
    }
}
