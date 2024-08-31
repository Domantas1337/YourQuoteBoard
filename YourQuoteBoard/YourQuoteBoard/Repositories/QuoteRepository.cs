using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Services;

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
            Quote? quote = await _applicationDbContext.Quotes
                                                      .Include(q => q.Book)
                                                      .Include(q => q.Tags)
                                                      .FirstOrDefaultAsync(q => q.QuoteId == quoteId);

            return quote;
        }

        public async Task<Quote?> GetByIdForRatingAsync(Guid quoteId)
        {
            Quote? quote = await _applicationDbContext.Quotes
                            .Include(q => q.QuoteRatings)
                            .Include(q => q.RatingSummaries)
                            .FirstOrDefaultAsync(q => q.QuoteId == quoteId);

            return quote;
        }

        public async Task DeleteQuoteAsync(Quote quote)
        {
            _applicationDbContext.Quotes.Remove(quote);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteQuoteCollectionAsync(ICollection<Quote> quotes)
        {
            _applicationDbContext.RemoveRange(quotes);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Quote>> GetQuotesByIds(ICollection<Guid> quoteIds)
        {
            List<Quote> quotes = await _applicationDbContext.Quotes
                .Where(q => quoteIds.Contains(q.QuoteId))
                .ToListAsync();

            return quotes;
        }

        public async Task<Quote?> CheckIfUserOwnsQuoteAsync(Guid quoteId, string userId)
        {
            Quote? quote = await _applicationDbContext.Quotes.FirstOrDefaultAsync(q => q.QuoteId.Equals(quoteId) && q.ApplicationUserId.Equals(userId));

            return quote;
        }

        public async Task SaveAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
