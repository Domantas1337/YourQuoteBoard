using AutoMapper;
using YourQuoteBoard.DTO.Book;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Services
{
    public class BookService(IBookRepository _bookRepository, IMapper _mapper) : IBookService
    {
        public async Task<BookAddDTO> AddBookAsync(BookAddDTO book)
        {
            Book bookToAdd = _mapper.Map<Book>(book);
            Book addedBook = await _bookRepository.AddBookAsync(bookToAdd);

            return book;
        }

        public async Task<List<BookDisplayDTO>> GetAllBooksAsync()
        {
            List<Book> books = await _bookRepository.GetAllBooksAsync();
            List<BookDisplayDTO> booksForDisplay = _mapper.Map<List<BookDisplayDTO>>(books);

            return booksForDisplay; 
        }
    }
}
