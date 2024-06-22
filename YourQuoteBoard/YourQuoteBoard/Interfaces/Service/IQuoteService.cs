using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Book;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IQuoteService
    {
        public Task<List<QuoteDisplayDTO>> GetQuotesByBookIdAsync(Guid bookId);
        public Task<QuoteAddDTO> AddQuoteAsync(QuoteAddDTO quoteAddDTO, string userId);
        public Task<List<QuoteDisplayDTO>> GetAllPersonalQuotesAsync(string userId);
        public Task<List<QuoteDisplayDTO>> GetAllQuotesAsync();
    }
}
