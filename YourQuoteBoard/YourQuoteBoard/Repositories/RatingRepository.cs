using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class RatingRepository(ApplicationDbContext _applicationDbContext) : IRatingRepository
    {
        public async Task<BookRating?> UpdateBookRatingAsync(BookRating bookRating)
        {
            var bookRatingToUpdate = await _applicationDbContext.BookRatings
                                       .FirstOrDefaultAsync(br => br.BookRatingId == bookRating.BookRatingId);

            if (bookRatingToUpdate == null)
            {
                return null;
            }

            bookRatingToUpdate.Rating = bookRating.Rating;

            try
            {
                await _applicationDbContext.SaveChangesAsync(); 
                return bookRatingToUpdate;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BookRating> AddBookRatingAsync(BookRating rating, string userId)
        {
            await _applicationDbContext.BookRatings.AddAsync(rating);
            await _applicationDbContext.SaveChangesAsync();

            return rating;
        }
        public async Task<List<BookRating>> GetAllBookRatingsAsync()
        {
            List<BookRating> bookRatings = await _applicationDbContext.BookRatings.ToListAsync();
            return bookRatings;
        }

        public async Task<BookRating?> GetBookRatingByUserAsync(string userId, Guid bookId)
        {
            BookRating? bookRating = await _applicationDbContext.BookRatings.FirstOrDefaultAsync(br => br.BookId.Equals(bookId) && br.ApplicationUserId.Equals(userId));
            return bookRating;
        }

        public async Task<List<BookRating>> GetRatingsForBookAsync(Guid bookId)
        {
            List<BookRating> bookRatings = await _applicationDbContext.BookRatings
                                                 .Where(br => br.BookId.Equals(bookId))
                                                 .ToListAsync();
            return bookRatings;                                                  
        }
    }
}
