using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IBookRepository
    {
        public Task<Book> UpdateBookRatingWhenARatingHasBeenAdded(Guid bookId, double rating);
        public Task<Book> UpdateBookRatingWhenARatingHasBeenUpdated(Guid bookId, double previousRating, double newRating);
        public Task<Book?> GetBookForDisplayByIdAsync(Guid id);
        public Task<Book> AddBookAsync(Book book);
        public Task<List<Book>> GetAllBooksAsync();
    }
}
