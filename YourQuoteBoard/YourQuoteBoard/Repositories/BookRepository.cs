using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.DTO.Rating.Book;
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

        public async Task<Book> UpdateBookRatingWhenARatingHasBeenAdded(Guid bookId, BookRatingDTO rating)
        {
            Book book = await FetchAndInitializeBook(bookId);

            double sumOfRatings = (double)(book.AverageRating != null ? book.AverageRating * book.NumberOfRatings : 0);
            double newSumOfRatings = sumOfRatings + rating.OverallRating;
            int newNumberOfRatings = (int) book.NumberOfRatings + 1;

            UpdateBookRating(book, newSumOfRatings, newNumberOfRatings);

            await _applicationDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookRatingWhenARatingHasBeenUpdated(Guid bookId, BookRatingDTO previousRating, BookRatingDTO newRating)
        {
            Book book = await FetchAndInitializeBook(bookId);

            double sumOfRatings = (double)(book.AverageRating != null ? book.AverageRating * book.NumberOfRatings : 0);
            double newSumOfRatings = sumOfRatings + newRating.OverallRating - previousRating.OverallRating;


            UpdateBookRating(book, newSumOfRatings, (int) book.NumberOfRatings);

            await _applicationDbContext.SaveChangesAsync();

            return book;
        }


        private async Task<Book> FetchAndInitializeBook(Guid bookId)
        {
            Book book = await _applicationDbContext.Books.FirstOrDefaultAsync(b => b.BookId.Equals(bookId));

            if (book.AverageRating == null)
            {
                book.AverageRating = 0;
                book.NumberOfRatings = 0;
            }

            return book;
        }

        private void UpdateBookRating(Book book, double newSumOfRatings, int newNumberOfRatings)
        {
            book.AverageRating = newSumOfRatings / newNumberOfRatings;
            book.NumberOfRatings = newNumberOfRatings;
        }

        public async Task DeleteBookAsync(Book book)
        {
            _applicationDbContext.Books.Remove(book);
            await _applicationDbContext.SaveChangesAsync();
        }
    }


}
