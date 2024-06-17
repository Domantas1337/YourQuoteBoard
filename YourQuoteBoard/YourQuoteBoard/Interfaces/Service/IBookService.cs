using YourQuoteBoard.DTO.Book;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IBookService
    {
        public Task<BookAddDTO> AddBookAsync(BookAddDTO book);
        public Task<List<BookDisplayDTO>> GetAllBooksAsync();
    }
}
