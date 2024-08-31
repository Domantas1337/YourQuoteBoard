using YourQuoteBoard.Entity.Quotes;

namespace YourQuoteBoard.DTO.Rating.Quote
{
    public class QuoteRatingDisplayDTO
    {
        public double OverallRating { get; set; }
        public required ICollection<QuoteSpecificRatingDTO> SpecificRatings { get; set; }
        public Guid QuoteId { get; set; }
    }
}
