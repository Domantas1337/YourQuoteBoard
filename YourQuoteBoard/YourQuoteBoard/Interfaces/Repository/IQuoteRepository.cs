using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IQuoteRepository
    {
        public Task<List<Quote>> GetQuotesByBookIdAsync(Guid bookId);
        public Task<Quote> AddQuoteAsync(Quote quote);
        public Task<List<Quote>> GetAllPersonalQuotesAsync(string userId);
        public Task<List<Quote>> GetAllQuotesAsync();
    }
}
