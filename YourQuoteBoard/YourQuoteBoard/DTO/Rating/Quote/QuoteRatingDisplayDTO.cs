using YourQuoteBoard.Entity;

namespace YourQuoteBoard.DTO.Rating.Quote
{
    public class QuoteRatingDisplayDTO
    {
        public double OverallRsting { get; set; }
        public required QuoteRatingInDetail QuoteRatingInDetail { get; set; }
        public Guid QuoteId { get; set; }
    }
}
