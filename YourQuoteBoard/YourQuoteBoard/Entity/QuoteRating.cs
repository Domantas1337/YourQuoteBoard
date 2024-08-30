using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity
{
    public class QuoteRating
    {
        public Guid QuoteRatingId { get; set; }
        public double OverallRating { get; set; }
        public ICollection<SpecificRating> SpecificRatings { get; } = new List<SpecificRating>();
        public Guid QuoteId { get; set; }
        public required Quote Quote { get; set; }
        public required string ApplicationUserId { get; set; }
    
        public void AddSpecificRatings(ICollection<SpecificRatingDTO>? specRatings)
        {
            if (specRatings == null) return;

            foreach (var specRating in specRatings) 
            {
                this.SpecificRatings.Add(
                    new SpecificRating 
                    { 
                        Rating = specRating.Rating, 
                        RatingCategory = specRating.RatingCategory
                    }
                    );
            }
        }
    }
}
