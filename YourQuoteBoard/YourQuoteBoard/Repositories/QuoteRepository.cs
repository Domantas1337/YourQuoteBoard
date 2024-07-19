using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Quote>> GetAllPersonalQuotesAsync(string userId)
        {
            List<Quote> personalQuotes = await _applicationDbContext.Quotes
                                               .Where(q => q.ApplicationUserId == userId)
                                               .ToListAsync();
            return personalQuotes;
        }

        public async Task<List<Quote>> GetAllQuotesAsync()
        {
            if (_applicationDbContext.Quotes == null)
                return new List<Quote>();

            var quotes = await _applicationDbContext.Quotes.ToListAsync();
            return quotes;
        }

        public async Task<List<Quote>> GetQuotesByBookIdAsync(Guid bookId)
        {
            List<Quote> quotes = await _applicationDbContext.Quotes
                                 .Where(q => q.BookId.Equals(bookId))
                                 .ToListAsync();

            return quotes;
        }

        public async Task<Quote?> GetQuoteByIdAsync(Guid quoteId)
        {
            Quote? quote = await _applicationDbContext.Quotes.Include(q => q.Book).FirstOrDefaultAsync(q => q.QuoteId == quoteId);
            return quote;
        }
    }
}
