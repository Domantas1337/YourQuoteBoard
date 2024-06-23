using YourQuoteBoard.DTO.Rating;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IRatingService
    {
        public Task<BookRatingDTO?> GetBookRatingByUserAsync(string userId, Guid bookId);
        public Task<BookRatingDTO> AddBookRatingAsync(BookRatingDTO rating, string userId);
        public Task<List<BookRatingDTO>> GetAllBookRatingsAsync();
        public Task<List<BookRatingDTO>> GetRatingsForBookAsync(Guid bookId);
    }
}
