using YourQuoteBoard.Entity;

namespace YourQuoteBoard.DTO.Rating.Quote
{
    public class QuoteRatingUpdateDTO
    {
        public Guid QuoteRatingId { get; set; }
        public required double OverallRating { get; set; }
        public QuoteRatingInDetail? QuoteRatingInDetail { get; set; }
        public Guid QuoteId { get; set; }
    }
}
