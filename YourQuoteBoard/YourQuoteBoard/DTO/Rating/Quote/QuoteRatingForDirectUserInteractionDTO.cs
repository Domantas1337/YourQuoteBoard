using YourQuoteBoard.Entity;

namespace YourQuoteBoard.DTO.Rating.Quote
{
    public class QuoteRatingForDirectUserInteractionDTO
    {
        public Guid QuoteRatingId { get; set; }
        public double OverallRating { get; set; }
        public required ICollection<SpecificRatingDTO> specificRatings { get; set; }
        public Guid QuoteId { get; set; }
    }
}
