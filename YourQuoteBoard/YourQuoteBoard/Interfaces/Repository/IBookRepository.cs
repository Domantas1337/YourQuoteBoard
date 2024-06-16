using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IBookRepository
    {
        public Task<Book> AddBookAsync(Book book);
        public Task<List<Book>> GetAllBooksAsync();
    }
}
