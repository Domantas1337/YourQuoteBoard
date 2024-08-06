using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IQuoteRatingRepository
    {
        public Task<QuoteRating?> UpdateQuoteRatingAsync(QuoteRating quoteRating);
        public Task<QuoteRating?> GetQuoteRatingByUserAsync(string userId, Guid quoteId);
        public Task<QuoteRating> AddQuoteRatingAsync(QuoteRating rating, string userId);
        public Task<List<QuoteRating>> GetAllQuoteRatingsAsync();
        public Task<List<QuoteRating>> GetRatingsForQuoteAsync(Guid quoteId);
        public Task<QuoteRating> GetQuoteRatingByIdAsync(Guid quoteRatingId);
    }
}
