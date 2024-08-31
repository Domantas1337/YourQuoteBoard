using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity.Quotes
{
    public class QuoteSpecificRating
    {
        public Guid QuoteSpecificRatingId { get; set; }
        public QuoteRatingCategory RatingCategory { get; set; }
        public double? Rating { get; set; }
        public Guid QuoteRatingId { get; set; }
        public QuoteRating QuoteRating { get; set; }
    }
}
