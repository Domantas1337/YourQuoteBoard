using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity.Quotes
{
    public class QuoteRatingSummary
    {
        public Guid QuoteRatingSummaryId { get; set; }
        public QuoteRatingCategory RatingCategory { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
        public Guid QuoteId { get; set; }
        public Quote Quote { get; set; }
    }
}
