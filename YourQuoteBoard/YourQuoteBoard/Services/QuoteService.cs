using AutoMapper;
using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.DTO.Tag;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Services
{
    public class QuoteService(IQuoteRepository _quoteRepository, ITagRepository _tagRepository, IMapper _mapper) : IQuoteService
    {
        public async Task<bool> CheckIfUserOwnsQuoteAsync(Guid quoteId, string userId)
        {
            Quote? isUsers = await _quoteRepository.CheckIfUserOwnsQuoteAsync(quoteId, userId);
            
            if (isUsers == null)
            {
                return false;
            }
            
            return true;
        }

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

            var tagsForQuote = await _tagRepository.GetTagsByTagIdAsync(quoteAddDTO.TagIds);
            quote.AddTags(tagsForQuote);  
            
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
                BookTitle = quote.Book.Title,
                AverageRating = quote.AverageOverallRating,
                NumberOfRatings = quote.NumberOfOverallRatings,
                Tags = _mapper.Map<ICollection<TagDisplayDTO>>(quote.Tags)       
            };
        }

        public async Task DeleteQuoteAsync(Guid quoteId)
        {
            Quote? quote = await _quoteRepository.GetQuoteByIdAsync(quoteId);

            if (quote == null)
            {
                throw new NullReferenceException("Quote not found");
            }
            else
            {
                await _quoteRepository.DeleteQuoteAsync(quote);
            }
        }

        public async Task DeleteQuoteCollectionAsync(ICollection<Guid> quoteIds)
        {
            List<Quote> quotes = await _quoteRepository.GetQuotesByIds(quoteIds);
            await _quoteRepository.DeleteQuoteCollectionAsync(quotes);
        }
    }
}
