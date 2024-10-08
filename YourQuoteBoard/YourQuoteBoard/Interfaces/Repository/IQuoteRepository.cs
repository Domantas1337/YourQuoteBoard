﻿using YourQuoteBoard.Entity.Quotes;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IQuoteRepository
    {
        public Task<List<Quote>> GetQuotesByBookIdAsync(Guid bookId);
        public Task<Quote> AddQuoteAsync(Quote quote);
        public Task<List<Quote>> GetAllPersonalQuotesAsync(string userId);
        public Task<List<Quote>> GetAllQuotesAsync();
        public Task<List<Quote>> GetQuotesByIds(ICollection<Guid> quoteIds);
        public Task<Quote?> GetQuoteByIdAsync(Guid quoteId);
        public Task<Quote?> GetByIdForRatingAsync(Guid quoteId);
        public Task DeleteQuoteAsync(Quote quote);
        public Task DeleteQuoteCollectionAsync(ICollection<Quote> quotes);
        public Task<Quote?> CheckIfUserOwnsQuoteAsync(Guid quoteId, string userId);
        public Task SaveAsync();
    }
}
