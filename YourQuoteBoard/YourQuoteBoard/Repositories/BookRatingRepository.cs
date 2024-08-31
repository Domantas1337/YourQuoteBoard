using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity.Books;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class BookRatingRepository(ApplicationDbContext _applicationDbContext) : IBookRatingRepository
    {
        public async Task<Guid> AddBookRatingAsync(BookRating rating, string userId)
        {
            await _applicationDbContext.BookRatings.AddAsync(rating);
            await _applicationDbContext.SaveChangesAsync();

            return rating.BookRatingId;
        }
        public async Task<List<BookRating>> GetAllBookRatingsAsync()
        {
            List<BookRating> bookRatings = await _applicationDbContext.BookRatings.ToListAsync();
            return bookRatings;
        }

        public async Task<BookRating?> GetBookRatingByUserAsync(string userId, Guid bookId)
        {
            BookRating? bookRating = await _applicationDbContext.BookRatings
                                                                .Include(br => br.SpecificRatings)
                                                                .FirstOrDefaultAsync(br => br.BookId.Equals(bookId) && br.ApplicationUserId.Equals(userId));
            return bookRating;
        }

        public async Task<List<BookRating>> GetRatingsForBookAsync(Guid bookId)
        {
            List<BookRating> bookRatings = await _applicationDbContext.BookRatings
                                                 .Where(br => br.BookId.Equals(bookId))
                                                 .ToListAsync();
            return bookRatings;                                                  
        }

        public async Task<BookRating?> GetBookRatingByIdAsync(Guid bookRatingId)
        {
            return await _applicationDbContext.BookRatings
                                              .Include(br => br.SpecificRatings)
                                              .FirstOrDefaultAsync(br => br.BookRatingId == bookRatingId);
        }
    }
}
