using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity.Books;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IBookRatingRepository
    {
        public Task<BookRating?> GetBookRatingByIdAsync(Guid bookRatingId);
        public Task<BookRating?> GetBookRatingByUserAsync(string userId, Guid bookId);
        public Task<Guid> AddBookRatingAsync(BookRating rating, string userId);
        public Task<List<BookRating>> GetAllBookRatingsAsync();
        public Task<List<BookRating>> GetRatingsForBookAsync(Guid bookId);
    }
}
