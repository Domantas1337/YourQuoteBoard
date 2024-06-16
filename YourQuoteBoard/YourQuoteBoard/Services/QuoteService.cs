using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YourQuoteBoard.Data;
using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Repositories;

namespace YourQuoteBoard.Services
{
    public class QuoteService(IQuoteRepository _quoteRepository, IMapper _mapper) : IQuoteService
    {
        public async Task<QuoteAddDTO> AddQuoteAsync(QuoteAddDTO quoteAddDTO)
        {
            Quote quote =  _mapper.Map<Quote>(quoteAddDTO);
            var addedQuote = await _quoteRepository.AddQuoteAsync(quote);

            return quoteAddDTO;
        }

        public async Task<List<QuoteDisplayDTO>> GetAllQuotesAsync()
        {
            var quotes = await _quoteRepository.GetAllQuotesAsync();
            List<QuoteDisplayDTO> quotesForDisplay = _mapper.Map<List<QuoteDisplayDTO>>(quotes);

            return quotesForDisplay;
        }
    }
}
