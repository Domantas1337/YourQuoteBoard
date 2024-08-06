using YourQuoteBoard.Entity;

namespace YourQuoteBoard.DTO.Rating.Quote
{
    public class QuoteRatingCreateDTO
    {
        public double OverallRating { get; set; }
        public required QuoteRatingInDetail QuoteRatingInDetail { get; set; }
        public Guid QuoteId { get; set; }
    }
}
