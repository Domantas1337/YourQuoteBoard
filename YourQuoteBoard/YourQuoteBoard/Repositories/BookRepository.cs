﻿using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.DTO.Rating;
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

        public async Task<Book> UpdateBookRatingWhenARatingHasBeenAdded(Guid bookId, double rating)
        {
            Book book = await FetchAndInitializeBook(bookId);

            double sumOfRatings = (double)(book.AverageRating != null ? book.AverageRating * book.NumberOfRatings : 0);
            double newSumOfRatings = sumOfRatings + rating;
            int newNumberOfRatings = (int) book.NumberOfRatings + 1;

            UpdateBookRating(book, newSumOfRatings, newNumberOfRatings);


            await _applicationDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBookRatingWhenARatingHasBeenUpdated(Guid bookId, double previousRating, double newRating)
        {
            Book book = await FetchAndInitializeBook(bookId);

            double sumOfRatings = (double)(book.AverageRating != null ? book.AverageRating * book.NumberOfRatings : 0);
            double newSumOfRatings = sumOfRatings + newRating;
            
            if (previousRating != 0)
            {
                newSumOfRatings -= previousRating;
            }

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
    }


}
