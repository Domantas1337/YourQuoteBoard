using YourQuoteBoard.DTO.Rating;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IRatingService
    {
        public Task<BookRatingForUpdateDTO> UpdateBookRatingAsync(BookRatingForUpdateDTO bookRatingDTO);
        public Task<BookRatingForDirectUserInteractionDTO?> GetBookRatingByUserAsync(string userId, Guid bookId);
        public Task<BookRatingCreateDTO> AddBookRatingAsync(BookRatingCreateDTO rating, string userId);
        public Task<List<BookRatingDisplayDTO>> GetAllBookRatingsAsync();
        public Task<List<BookRatingDisplayDTO>> GetRatingsForBookAsync(Guid bookId);
    }
}
