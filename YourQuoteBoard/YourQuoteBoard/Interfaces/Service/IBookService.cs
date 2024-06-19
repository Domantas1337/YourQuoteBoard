using YourQuoteBoard.DTO.Book;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IBookService
    {
        public Task<BookDisplayDTO> GetBookForDisplayByIdAsync(Guid id);
        public Task<BookAddDTO> AddBookAsync(BookAddDTO book);
        public Task<List<BookDisplayDTO>> GetAllBooksAsync();
    }
}
