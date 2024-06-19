using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.Entity;
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

        public async Task<Book?> GetBookForDisplayByIdAsync(Guid id)
        {
            if (_applicationDbContext.Books == null)
            {
                return null;
            }

            Book? book = await _applicationDbContext.Books.FirstOrDefaultAsync(b => b.BookId == id);

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
    }
}
