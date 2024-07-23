using AutoMapper;
using SixLabors.ImageSharp;
using YourQuoteBoard.DTO.Book;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Exceptions;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;
using YourQuoteBoard.Utilities;

namespace YourQuoteBoard.Services
{
    public class BookService(IBookRepository _bookRepository, ITagRepository _tagRepository, IMapper _mapper) : IBookService
    {
        public async Task<BookAddDTO> AddBookAsync(BookAddDTO book)
        {
            var pngPath = FileFormToPNGConverter.ConvertFileFormToPNG(book.CoverImage.FileName, book.CoverImage);

            Book bookToAdd = _mapper.Map<Book>(book);
            bookToAdd.NumberOfRatings = 0;
            bookToAdd.AverageRating = 0;
            bookToAdd.CoverImagePath = pngPath.Result;

            ICollection<Tag> tags = await _tagRepository.GetTagsByTagIdAsync(book.TagIds);
            bookToAdd.AddTags(tags);

            Book addedBook = await _bookRepository.AddBookAsync(bookToAdd);

            return book;
        }

        public async Task<BookDisplayDTO?> GetBookForDisplayByIdAsync(Guid id)
        {
            Book? book = await _bookRepository.GetBookByIdAsync(id);
            
            if(book == null)
            {
                throw new EntityNotFoundException($"Entity with ID {id} was not found");
            }
            
            BookDisplayDTO? bookDisplayDTO = _mapper.Map<BookDisplayDTO>(book);

            return bookDisplayDTO;
        }

        public async Task<List<BookDisplayDTO>> GetAllBooksAsync()
        {
            List<Book> books = await _bookRepository.GetAllBooksAsync();
            List<BookDisplayDTO> booksForDisplay = _mapper.Map<List<BookDisplayDTO>>(books);

            return booksForDisplay; 
        }
    }
}
