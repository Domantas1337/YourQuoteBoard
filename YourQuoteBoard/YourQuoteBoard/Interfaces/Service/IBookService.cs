using YourQuoteBoard.DTO.Book;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IBookService
    {
        public Task<BookAddDTO> AddBook(BookAddDTO book);
        public Task<List<BookDisplayDTo>> GetAllBooks();
    }
}
