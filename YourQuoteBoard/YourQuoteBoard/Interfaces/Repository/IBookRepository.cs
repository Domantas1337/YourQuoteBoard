﻿using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.Entity.Books;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IBookRepository
    {
        public Task<Book> GetByIdForRatingAsync(Guid bookId);
        public Task SaveAsync();
        public Task<Book?> GetBookByIdAsync(Guid id);
        public Task<Book> AddBookAsync(Book book);
        public Task<List<Book>> GetAllBooksAsync();
        public Task DeleteBookAsync(Book book);
    }
}
