using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity
{
    public class SpecificRating
    {
        public Guid SpecificRatingId { get; set; }
        public RatingCategory RatingCategory { get; set; }
        public double? Rating { get; set; }
        public Guid QuoteRatingId { get; set; }
        public QuoteRating QuoteRating { get; set; }
    }
}
