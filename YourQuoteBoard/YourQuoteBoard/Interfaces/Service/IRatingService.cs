using YourQuoteBoard.DTO.Rating;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IRatingService
    {
        public Task<BookRatingDTO> AddBookRating(BookRatingDTO rating, string userId);
        public Task<List<BookRatingDTO>> GetAllBookRatingsAsync();
        public Task<List<BookRatingDTO>> GetRatingsForBookAsync(Guid bookId);
    }
}
