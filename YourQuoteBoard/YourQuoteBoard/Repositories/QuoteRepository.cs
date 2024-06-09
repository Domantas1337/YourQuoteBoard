using YourQuoteBoard.Data;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class QuoteRepository(ApplicationDbContext _applicationDbContext) : IQuoteRepository
    {
        public async Task<Quote> AddQuoteAsync(Quote quote)
        {
            await _applicationDbContext.AddAsync(quote);
            await _applicationDbContext.SaveChangesAsync();

            return quote;
        }

        public async Task<List<Quote>> GetAllQuotesAsync()
        {
            if (_applicationDbContext.Quotes == null)
                return new List<Quote>();

            var quotes = await _applicationDbContext.Quotes.ToListAsync();
            return quotes;
        }
    }
}
