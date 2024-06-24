using YourQuoteBoard.DTO.Rating;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IRatingService
    {
        public Task<BookRatingUpdateDTO> UpdateBookRatingAsync(BookRatingUpdateDTO bookRatingDTO);
        public Task<BookRatingUpdateDTO?> GetBookRatingByUserAsync(string userId, Guid bookId);
        public Task<BookRatingUpdateDTO> AddBookRatingAsync(BookRatingDTO rating, string userId);
        public Task<List<BookRatingDTO>> GetAllBookRatingsAsync();
        public Task<List<BookRatingDTO>> GetRatingsForBookAsync(Guid bookId);
    }
}
