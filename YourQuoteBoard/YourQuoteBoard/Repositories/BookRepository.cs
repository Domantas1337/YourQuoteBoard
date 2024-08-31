using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.Entity.Books;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class BookRepository(ApplicationDbContext _applicationDbContext) : IBookRepository
    {
        public async Task<Book> AddBookAsync(Book book)
        {
            await _applicationDbContext.AddAsync(book);
            await _applicationDbContext.SaveChangesAsync();

            return book;
        }

        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            if (_applicationDbContext.Books == null)
            {
                return null;
            }

            Book? book = await _applicationDbContext.Books.Include(b => b.Tags).FirstOrDefaultAsync(b => b.BookId == id);

            return book;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            if (_applicationDbContext.Books == null)
            {
                return new List<Book>();
            }

            List<Book> books = await _applicationDbContext.Books.ToListAsync();

            return books;
        }

        public async Task DeleteBookAsync(Book book)
        {
            _applicationDbContext.Books.Remove(book);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Book?> GetByIdForRatingAsync(Guid bookId)
        {
            return await _applicationDbContext.Books
                                              .Include(b => b.BookRatings)
                                              .Include(b => b.RatingSummaries)
                                              .FirstOrDefaultAsync(b => b.BookId == bookId);
        }
    }


}
