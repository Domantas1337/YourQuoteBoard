using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class QuoteRatingRepository(ApplicationDbContext _applicationDbContext) : IQuoteRatingRepository
    {
        public async Task<QuoteRating?> UpdateQuoteRatingAsync(QuoteRating quoteRating)
        {
            var quoteRatingToUpdate = await _applicationDbContext.QuoteRatings
                                       .FirstOrDefaultAsync(br => br.QuoteRatingId == quoteRating.QuoteRatingId);

            if (quoteRatingToUpdate == null)
            {
                return null;
            }

            quoteRatingToUpdate.OverallRating = quoteRating.OverallRating;

            try
            {
                await _applicationDbContext.SaveChangesAsync();
                return quoteRatingToUpdate;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<QuoteRating> AddQuoteRatingAsync(QuoteRating rating, string userId)
        {
            await _applicationDbContext.QuoteRatings.AddAsync(rating);
            await _applicationDbContext.SaveChangesAsync();

            return rating;
        }
        public async Task<List<QuoteRating>> GetAllQuoteRatingsAsync()
        {
            List<QuoteRating> quoteRatings = await _applicationDbContext.QuoteRatings.ToListAsync();
            return quoteRatings;
        }

        public async Task<QuoteRating?> GetQuoteRatingByUserAsync(string userId, Guid quoteId)
        {
            QuoteRating? quoteRating = await _applicationDbContext.QuoteRatings.FirstOrDefaultAsync(br => br.QuoteId.Equals(quoteId) && br.ApplicationUserId.Equals(userId));
            return quoteRating;
        }

        public async Task<List<QuoteRating>> GetRatingsForQuoteAsync(Guid quoteId)
        {
            List<QuoteRating> quoteRatings = await _applicationDbContext.QuoteRatings
                                                 .Where(br => br.QuoteId.Equals(quoteId))
                                                 .ToListAsync();
            return quoteRatings;
        }


    }
}
