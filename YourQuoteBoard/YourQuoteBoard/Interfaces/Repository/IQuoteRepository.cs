using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IQuoteRepository
    {
        public Task<Quote> AddQuoteAsync(Quote quote);
        public Task<List<Quote>> GetAllQuotesAsync();
    }
}
