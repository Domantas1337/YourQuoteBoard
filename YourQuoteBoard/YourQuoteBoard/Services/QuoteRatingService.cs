using AutoMapper;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Enums;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;
using YourQuoteBoard.Utilities;

namespace YourQuoteBoard.Services
{
    public class QuoteRatingService(IQuoteRatingRepository _quoteRatingRepository, IQuoteRepository _quoteRepository, IMapper _mapper) : IQuoteRatingService
    {
        public async Task AddQuoteRatingAsync(QuoteRatingCreateDTO rating, string userId)
        {
            Quote quote = await _quoteRepository.GetByIdForRatingAsync(rating.QuoteId);
            
            RatingUtils.UpdateOverallRatingWhenAdded<Quote>(quote, rating.OverallRating);
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
            Quote quote = await _quoteRepository.GetByIdForRatingAsync(quoteRatingDTO.QuoteId);

            RatingUtils.UpdateOverallRatingWhenUpdated<Quote>(quote, currentQuoteRating.OverallRating, quoteRatingDTO.OverallRating);
            UpdateSpecificRatings(quote, currentQuoteRating.SpecificRatings, quoteRatingDTO.SpecificRatings); 
            await _quoteRepository.SaveAsync();

            currentQuoteRating.OverallRating = quoteRatingDTO.OverallRating;
            await _quoteRepository.SaveAsync();

            return quoteRatingDTO;
        }

        public void UpdateSpecificRatings(Quote quote,
                                          ICollection<QuoteSpecificRating> currentRatings, 
                                          ICollection<QuoteSpecificRatingDTO> newRatings
                                          )
        {
            var currentRatingDictionary = currentRatings.ToDictionary(sr => sr.RatingCategory);
            var currentSummaryDictionary = quote.RatingSummaries.ToDictionary(sr => sr.RatingCategory);

            foreach (QuoteSpecificRatingDTO newRating in newRatings)
            {
                if(currentRatingDictionary.TryGetValue(newRating.RatingCategory, out var currentRating))
                {
                    QuoteRatingSummary ratingSummary = currentSummaryDictionary.GetValueOrDefault(newRating.RatingCategory);
                    double currentTotal = ratingSummary.AverageRating * ratingSummary.NumberOfRatings;
                    ratingSummary.AverageRating = (currentTotal - (double)currentRating.Rating) + (double)newRating.Rating;

                    currentRating.Rating = newRating.Rating;
                }
                else if(newRating.Rating != null)
                {
                    quote.AddRatingSummary(newRating);
                    currentRatings.Add( 
                        new QuoteSpecificRating
                        {
                            Rating = newRating.Rating,
                            RatingCategory = newRating.RatingCategory
                        }
                     );
                }
            }
        }




        private void UpdateSpecificRatingWhenAdded(Quote quote, ICollection<QuoteSpecificRatingDTO> specificRatings)
        {
            var ratingSummaryDict = quote.RatingSummaries
                                    .ToDictionary(summary => summary.RatingCategory);

            foreach (QuoteSpecificRatingDTO rating in specificRatings)
            {
                if (ratingSummaryDict.TryGetValue(rating.RatingCategory, out var summary)) 
                {
                    double currentTotal = summary.AverageRating * summary.NumberOfRatings;
                    currentTotal += (double) rating.Rating;
                    summary.NumberOfRatings += 1;
                    summary.AverageRating = currentTotal / summary.NumberOfRatings;
                }
                else
                {
                    quote.AddRatingSummary(rating);
                }
            }

        }

        public async Task<ICollection<QuoteSpecificRating>> GetSpecificRatingsByRatingId(Guid quoteRatingId)
        {
            var quoteRating = await _quoteRatingRepository.GetRatingWithSepcificRatingsByIdAsync(quoteRatingId);
            var specificRatings = quoteRating.SpecificRatings;

            QuoteRatingCategory[] ratingCategories = (QuoteRatingCategory[]) Enum.GetValues(typeof(QuoteRatingCategory));
            Dictionary<QuoteRatingCategory, QuoteSpecificRating> specificRatingDictionary = specificRatings.ToDictionary(c => c.RatingCategory);
            
            foreach(var ratingCategory in ratingCategories)
            {
                if (!specificRatingDictionary.ContainsKey(ratingCategory))
                {
                    specificRatings.Add(new QuoteSpecificRating
                    {
                        RatingCategory = ratingCategory,
                        Rating = null
                    });
                }
            }

            return specificRatings;
        }
    }
}
