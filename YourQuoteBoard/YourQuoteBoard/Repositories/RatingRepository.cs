using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class RatingRepository(ApplicationDbContext _applicationDbContext) : IRatingRepository
    {

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
        public async Task<List<BookRating>> GetRatingsForBookAsync(Guid bookId)
        {
            List<BookRating> bookRatings = await _applicationDbContext.BookRatings
                                                 .Where(br => br.BookId.Equals(bookId))
                                                 .ToListAsync();
            return bookRatings;                                                  
        }
    }
}
