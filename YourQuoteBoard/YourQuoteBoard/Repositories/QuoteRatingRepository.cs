using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class QuoteRatingRepository(ApplicationDbContext _applicationDbContext) : IQuoteRatingRepository
    {
        public async Task SaveAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<QuoteRating> AddQuoteRatingAsync(QuoteRating rating, string userId)
        {
            await _applicationDbContext.QuoteRatings.AddAsync(rating);
            await _applicationDbContext.SaveChangesAsync();

            return rating;
        }
        public async Task<List<QuoteRating>> GetAllQuoteRatingsAsync()
        {
            List<QuoteRating> quoteRatings = await _applicationDbContext.QuoteRatings
                                                                        .ToListAsync();
            return quoteRatings;
        }

        public async Task<QuoteRating?> GetQuoteRatingByUserAsync(string userId, Guid quoteId)
        {
            QuoteRating? quoteRating = await _applicationDbContext.QuoteRatings
                                            .Include(r => r.SpecificRatings)
                                            .FirstOrDefaultAsync(br => br.QuoteId.Equals(quoteId) && br.ApplicationUserId.Equals(userId));
            return quoteRating;
        }

        public async Task<List<QuoteRating>> GetRatingsForQuoteAsync(Guid quoteId)
        {
            List<QuoteRating> quoteRatings = await _applicationDbContext.QuoteRatings
                                                 .Where(br => br.QuoteId.Equals(quoteId))
                                                 .ToListAsync();
            return quoteRatings;
        }

        public async Task<QuoteRating?> GetQuoteRatingByIdAsync(Guid quoteRatingId)
        {
            QuoteRating quoteRating = await _applicationDbContext
                                        .QuoteRatings
                                        .Include(qr => qr.SpecificRatings)
                                        .FirstOrDefaultAsync(qr => qr.QuoteRatingId == quoteRatingId);
            return quoteRating;
        }

        public async Task<QuoteRating> GetRatingWithSepcificRatingsByIdAsync(Guid quoteRatingId)
        {
            var quoteRaintg = await _applicationDbContext.QuoteRatings
                                        .Include(sr => sr.SpecificRatings)
                                        .FirstOrDefaultAsync(sr => sr.QuoteRatingId.Equals(quoteRatingId));
                                        

               
            return quoteRaintg;
        }
    }
}
