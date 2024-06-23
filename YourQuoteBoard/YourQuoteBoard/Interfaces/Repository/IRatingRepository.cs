using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IRatingRepository
    {
        public Task<BookRating> AddBookRatingAsync(BookRating rating, string userId);
        public Task<List<BookRating>> GetAllBookRatingsAsync();
        public Task<List<BookRating>> GetRatingsForBookAsync(Guid bookId);
    }
}
