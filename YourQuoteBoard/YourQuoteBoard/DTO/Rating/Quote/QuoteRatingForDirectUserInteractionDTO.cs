namespace YourQuoteBoard.DTO.Rating.Quote
{
    public class QuoteRatingForDirectUserInteractionDTO
    {
        public Guid QuoteRatingId { get; set; }
        public double OverallRating { get; set; }
        public Guid QuoteId { get; set; }
    }
}
