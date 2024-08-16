using AutoMapper;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Services
{
    public class QuoteRatingService(IQuoteRatingRepository _quoteRatingRepository, IQuoteRepository _quoteRepository, IMapper _mapper) : IQuoteRatingService
    {
        public async Task AddQuoteRatingAsync(QuoteRatingCreateDTO rating, string userId)
        {
 
            Quote quote = await _quoteRepository.GetQuoteByIdForRatingAsync(rating.QuoteId);
            
            UpdateOverallRatingWhenAdded(quote, rating.OverallRating);
            UpdateSpecificRatingWhenAdded(quote, rating.SpecificRatings);

            await _quoteRepository.SaveAsync();

            QuoteRating quoteRating = new QuoteRating
            {
                ApplicationUserId = userId,
                OverallRating = rating.OverallRating,
                Quote = quote
            };
            quoteRating.AddSpecificRatings(rating.SpecificRatings);

            await _quoteRatingRepository.AddQuoteRatingAsync(quoteRating, userId);
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
            QuoteRating currentQuoteRating = await _quoteRatingRepository.GetQuoteRatingByIdAsync(quoteRatingDTO.QuoteRatingId);
            Quote quote = await _quoteRepository.GetQuoteByIdForRatingAsync(quoteRatingDTO.QuoteId);

            UpdateOverallRatingWhenUpdated(quote, currentQuoteRating.OverallRating, quoteRatingDTO.OverallRating);
            UpdateSpecificRatings(quote, currentQuoteRating.SpecificRatings, quoteRatingDTO.SpecificRatings);
            await _quoteRepository.SaveAsync();

            currentQuoteRating.OverallRating = quoteRatingDTO.OverallRating;
            await _quoteRepository.SaveAsync();

            return quoteRatingDTO;
        }

        public void UpdateSpecificRatings(Quote quote,
                                          ICollection<SpecificRating> currentRatings, 
                                          ICollection<SpecificRating> newRatings
                                          )
        {
            var currentRatingDictionary = currentRatings.ToDictionary(sr => sr.RatingCategory);
            var currentSummaryDictionary = quote.RatingSummaries.ToDictionary(sr => sr.RatingCategory);

            foreach (SpecificRating newRating in newRatings)
            {
                if(currentRatingDictionary.TryGetValue(newRating.RatingCategory, out var currentRating))
                {
                    RatingSummary ratingSummary = currentSummaryDictionary.GetValueOrDefault(newRating.RatingCategory);
                    double currentTotal = ratingSummary.AverageRating * ratingSummary.NumberOfRatings;
                    ratingSummary.AverageRating = (currentTotal - currentRating.Rating) + newRating.Rating;

                    currentRating.Rating = newRating.Rating;
                }
                else
                {
                    quote.AddRatingSummary(newRating);
                    currentRatings.Add(newRating);
                }
            }
        }

        private void UpdateOverallRatingWhenUpdated(Quote quote, double currentOverallRating, double newOverallRating)
        {
            double currentTotalRating = quote.AverageOverallRating * quote.NumberOfOverallRatings;
            currentTotalRating = (currentTotalRating - currentOverallRating) + newOverallRating;
            quote.AverageOverallRating = currentTotalRating / quote.NumberOfOverallRatings;

        }

        private void UpdateOverallRatingWhenAdded(Quote quote, double overallRating)
        {
            double currentTotalRating = quote.AverageOverallRating * quote.NumberOfOverallRatings;
            quote.NumberOfOverallRatings += 1;
            quote.AverageOverallRating = (currentTotalRating +  overallRating) / (double)quote.NumberOfOverallRatings;
        }

        private void UpdateSpecificRatingWhenAdded(Quote quote, ICollection<SpecificRating> specificRatings)
        {
            var ratingSummaryDict = quote.RatingSummaries
                                    .ToDictionary(summary => summary.RatingCategory);

            foreach (SpecificRating rating in specificRatings)
            {
                if (ratingSummaryDict.TryGetValue(rating.RatingCategory, out var summary)) 
                {
                    double currentTotal = summary.AverageRating * summary.NumberOfRatings;
                    currentTotal += rating.Rating;
                    summary.NumberOfRatings += 1;
                    summary.AverageRating = currentTotal / summary.NumberOfRatings;
                }
                else
                {
                    quote.AddRatingSummary(rating);
                }
            }

        }


    }
}
