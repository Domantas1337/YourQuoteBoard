using AutoMapper;
using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Services
{
    public class QuoteService(IQuoteRepository _quoteRepository, IMapper _mapper) : IQuoteService
    {
        public async Task<List<QuoteDisplayDTO>> GetQuotesByBookIdAsync(Guid bookId)
        {
            List<Quote> quotes = await _quoteRepository.GetQuotesByBookIdAsync(bookId);
            List<QuoteDisplayDTO> quoteDisplayDTOs = _mapper.Map<List<QuoteDisplayDTO>>(quotes);

            return quoteDisplayDTOs;
        }
        public async Task<QuoteAddDTO> AddQuoteAsync(QuoteAddDTO quoteAddDTO, string userId)
        {
            Quote quote =  _mapper.Map<Quote>(quoteAddDTO, opts =>
            {
                opts.Items["userId"] = userId;
            });

            var addedQuote = await _quoteRepository.AddQuoteAsync(quote);

            return quoteAddDTO;
        }

        public async Task<List<QuoteDisplayDTO>> GetAllPersonalQuotesAsync(string userId)
        {
            var personalQuotes = await _quoteRepository.GetAllPersonalQuotesAsync(userId);
            List<QuoteDisplayDTO> quotesForDisplay = _mapper.Map<List<QuoteDisplayDTO>>(personalQuotes);

            return quotesForDisplay;
        }

        public async Task<List<QuoteDisplayDTO>> GetAllQuotesAsync()
        {
            var quotes = await _quoteRepository.GetAllQuotesAsync();
            List<QuoteDisplayDTO> quotesForDisplay = _mapper.Map<List<QuoteDisplayDTO>>(quotes);

            return quotesForDisplay;
        }

        public async Task<QuoteFullDisplayDTO?> GetQuoteForQuoteDedicatedPageAsync(Guid quoteId)
        {
            var quote = await _quoteRepository.GetQuoteByIdAsync(quoteId);

            if (quote == null)
            {
                return null;
            }

            return ConvertToFullDisplayDTO(quote);
        }

        public QuoteFullDisplayDTO ConvertToFullDisplayDTO(Quote quote)
        {
            return new QuoteFullDisplayDTO
            {

                Title = quote.Title,
                Description = quote.Description,
                Author = quote.Author,
                Created = quote.Created,
                BookId = quote.BookId,
                BookTitle = quote.Book.Title
            };
        }
    }
}
