using YourQuoteBoard.DTO.Rating.Book;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IBookRatingService
    {
        public Task<BookRatingUpdateDTO> UpdateBookRatingAsync(BookRatingUpdateDTO bookRatingDTO, string userId);
        public Task<BookRatingForDirectUserInteractionDTO?> GetBookRatingByUserAsync(string userId, Guid bookId);
        public Task AddBookRatingAsync(BookRatingCreateDTO rating, string userId);
        public Task<List<BookRatingDisplayDTO>> GetAllBookRatingsAsync();
        public Task<List<BookRatingDisplayDTO>> GetRatingsForBookAsync(Guid bookId);
    }
}
