using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Services
{
    public class QuoteRatingService(IQuoteRatingRepository _quoteRatingRepository, IQuoteRepository _quoteRepository, IMapper _mapper) : IQuoteRatingService
    {
        public async Task<QuoteRatingCreateDTO> AddQuoteRatingAsync(QuoteRatingCreateDTO rating, string userId)
        {
            QuoteRating quoteRating = _mapper.Map<QuoteRating>(rating, opts =>
            {
                opts.Items["userId"] = userId;
            });
            QuoteRating addedQuoteRating = await _quoteRatingRepository.AddQuoteRatingAsync(quoteRating, userId);

            Quote quote = await _quoteRepository.UpdateQuoteRatingWhenARatingHasBeenAdded(rating.QuoteId, rating.OverallRating);

            return _mapper.Map<QuoteRatingCreateDTO>(addedQuoteRating);
        }

        public async Task<List<QuoteRatingDisplayDTO>> GetAllQuoteRatingsAsync()
        {
            List<QuoteRating> quoteRatings = await _quoteRatingRepository.GetAllQuoteRatingsAsync();
            List<QuoteRatingDisplayDTO> quoteRatingDTOs = _mapper.Map<List<QuoteRatingDisplayDTO>>(quoteRatings);

            return quoteRatingDTOs;
        }

        public async Task<QuoteRatingForDirectUserInteractionDTO?> GetQuoteRatingByUserAsync(string userId, Guid quoteId)
        {
            QuoteRating? quoteRating = await _quoteRatingRepository.GetQuoteRatingByUserAsync(userId, quoteId);

            if (quoteRating == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<QuoteRatingForDirectUserInteractionDTO>(quoteRating);
            }
        }

        public async Task<List<QuoteRatingDisplayDTO>> GetRatingsForQuoteAsync(Guid quoteId)
        {
            List<QuoteRating> quoteRatings = await _quoteRatingRepository.GetRatingsForQuoteAsync(quoteId);
            List<QuoteRatingDisplayDTO> quoteRatingDTOs = _mapper.Map<List<QuoteRatingDisplayDTO>>(quoteRatings);

            return quoteRatingDTOs;
        }

        public async Task<QuoteRatingUpdateDTO> UpdateQuoteRatingAsync(QuoteRatingUpdateDTO quoteRatingDTO)
        {
            QuoteRating newQuoteRating = _mapper.Map<QuoteRating>(quoteRatingDTO);
            QuoteRating currentQuoteRating = await _quoteRatingRepository.GetQuoteRatingByIdAsync(quoteRatingDTO.QuoteRatingId);
            QuoteRating? quoteRating = await _quoteRatingRepository.UpdateQuoteRatingAsync(newQuoteRating);
            

            Quote quote = await _quoteRepository.UpdateQuoteRatingWhenARatingHasBeenUpdated(quoteRatingDTO.QuoteId, currentQuoteRating, newQuoteRating);

            return quoteRatingDTO;
        }
    }
}
