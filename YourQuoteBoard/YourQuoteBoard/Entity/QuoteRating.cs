namespace YourQuoteBoard.Entity
{
    public class QuoteRating
    {
        public Guid QuoteRatingId { get; set; }
        public double Rating { get; set; }
        public Guid QuoteId { get; set; }
        public required Quote Quote { get; set; }
        public required string ApplicationUserId { get; set; }
    }
}
