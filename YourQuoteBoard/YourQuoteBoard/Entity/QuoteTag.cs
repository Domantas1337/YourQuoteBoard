namespace YourQuoteBoard.Entity
{
    public class QuoteTag
    {
        public Guid QuoteTagId { get; set; }
        public required string Tag { get; set; }
        public required bool IsDefault { get; set; }
    }
}
