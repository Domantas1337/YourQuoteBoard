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
            Quote? quote = await _applicationDbContext.Quotes.Include(q => q.Book).Include(q => q.Tags).FirstOrDefaultAsync(q => q.QuoteId == quoteId);

            return quote;
        }

        public async Task<Quote> UpdateQuoteRatingWhenARatingHasBeenAdded(Guid quoteId, double rating)
        {
            Quote quote = await FetchAndInitializeQuote(quoteId);

            double sumOfRatings = (double)(quote.AverageRating != null ? quote.AverageRating * quote.NumberOfRatings : 0);
            double newSumOfRatings = sumOfRatings + rating;
            int newNumberOfRatings = (int)quote.NumberOfRatings + 1;

            UpdateQuoteRating(quote, newSumOfRatings, newNumberOfRatings);

            await _applicationDbContext.SaveChangesAsync();
            return quote;
        }

        public async Task<Quote> UpdateQuoteRatingWhenARatingHasBeenUpdated(Guid quoteId, QuoteRating currentRating, QuoteRating newRating)
        {
            Quote quote = await FetchAndInitializeQuote(quoteId);

            double sumOfRatings = (double)(quote.AverageRating != null ? quote.AverageRating * quote.NumberOfRatings : 0);
            double newSumOfRatings = sumOfRatings + newRating.OverallRating;

            if (currentRating.OverallRating != 0)
            {
                newSumOfRatings -= currentRating.OverallRating;
            }

            UpdateQuoteRating(quote, newSumOfRatings, (int)quote.NumberOfRatings);

            await _applicationDbContext.SaveChangesAsync();

            return quote;
        }

        private async Task<Quote> FetchAndInitializeQuote(Guid quoteId)
        {
            Quote quote = await _applicationDbContext.Quotes.FirstOrDefaultAsync(q => q.QuoteId.Equals(quoteId));

            if (quote.AverageRating == null)
            {
                quote.AverageRating = 0;
                quote.NumberOfRatings = 0;
            }

            return quote;
        }

        private void UpdateQuoteRating(Quote quote, double newSumOfRatings, int newNumberOfRatings)
        {
            quote.AverageRating = newSumOfRatings / newNumberOfRatings;
            quote.NumberOfRatings = newNumberOfRatings;
        }
    }
}
