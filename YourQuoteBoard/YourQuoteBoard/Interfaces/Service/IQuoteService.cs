using YourQuoteBoard.DTO;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IQuoteService
    {
        public Task<QuoteAddDTO> AddQuoteAsync(QuoteAddDTO quoteAddDTO);
        public Task<List<QuoteDisplayDTO>> GetAllQuotesAsync();
    }
}
