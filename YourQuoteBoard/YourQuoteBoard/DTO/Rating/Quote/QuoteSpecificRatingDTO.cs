using YourQuoteBoard.Enums;

namespace YourQuoteBoard.DTO.Rating.Quote
{
    public class QuoteSpecificRatingDTO
    {
        public Guid QuoteSpecificRatingId { get; set; }
        public double Rating { get; set; }
        public QuoteRatingCategory RatingCategory { get; set; }
    }
}
