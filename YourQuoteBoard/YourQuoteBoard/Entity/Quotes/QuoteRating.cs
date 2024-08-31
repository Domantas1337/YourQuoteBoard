using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity.Quotes
{
    public class QuoteRating
    {
        public Guid QuoteRatingId { get; set; }
        public double OverallRating { get; set; }
        public ICollection<QuoteSpecificRating> SpecificRatings { get; } = new List<QuoteSpecificRating>();
        public Guid QuoteId { get; set; }
        public required Quote Quote { get; set; }
        public required string ApplicationUserId { get; set; }

        public void AddSpecificRatings(ICollection<QuoteSpecificRatingDTO>? specRatings)
        {
            if (specRatings == null) return;

            foreach (var specRating in specRatings)
            {
                SpecificRatings.Add(
                    new QuoteSpecificRating
                    {
                        Rating = specRating.Rating,
                        RatingCategory = specRating.RatingCategory
                    }
                    );
            }
        }
    }
}
