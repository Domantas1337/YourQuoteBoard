namespace YourQuoteBoard.Entity
{
    public class QuoteRating
    {
        public Guid QuoteRatingId { get; set; }
        public double OverallRating { get; set; }
        public double OriginalityRating { get; set; }
        public double InspirationalValueRating {  get; set; }
        public double RelevanceToTheTopicRating { get; set; }
        public Guid QuoteId { get; set; }
        public required Quote Quote { get; set; }
        public required string ApplicationUserId { get; set; }
    }
}
