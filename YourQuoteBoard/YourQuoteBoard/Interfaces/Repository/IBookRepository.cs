using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IBookRepository
    {
        public Task<Book> UpdateBookRatingWhenARatingHasBeenAdded(Guid bookId, BookRatingDTO rating);
        public Task<Book> UpdateBookRatingWhenARatingHasBeenUpdated(Guid bookId, BookRatingDTO previousRating, BookRatingDTO newRating);
        public Task<Book?> GetBookByIdAsync(Guid id);
        public Task<Book> AddBookAsync(Book book);
        public Task<List<Book>> GetAllBooksAsync();
    }
}
