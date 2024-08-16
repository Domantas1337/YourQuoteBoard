using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity
{
    public class RatingSummary
    {
        public Guid RatingSummaryId { get; set; }
        public RatingCategory RatingCategory { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
        public Guid QuoteId { get; set; }
        public Quote Quote { get; set; }
    }
}
