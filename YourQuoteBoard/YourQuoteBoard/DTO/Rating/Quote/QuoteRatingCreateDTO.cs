using YourQuoteBoard.Entity;

namespace YourQuoteBoard.DTO.Rating.Quote
{
    public class QuoteRatingCreateDTO
    {
        public double OverallRating { get; set; }
        public ICollection<QuoteSpecificRatingDTO>? SpecificRatings { get; set; }
        public Guid QuoteId { get; set; }
    }
}
