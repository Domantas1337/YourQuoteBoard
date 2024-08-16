using YourQuoteBoard.Entity;

namespace YourQuoteBoard.DTO.Rating.Quote
{
    public class QuoteRatingDisplayDTO
    {
        public double OverallRsting { get; set; }
        public required ICollection<SpecificRating> SpecificRatings { get; set; }
        public Guid QuoteId { get; set; }
    }
}
