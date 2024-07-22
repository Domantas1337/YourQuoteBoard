namespace YourQuoteBoard.Entity
{
    public class BookTag
    {
        public Guid BookTagId { get; set; }
        public required string Tag { get; set; }
        public required bool IsDefault { get; set; }
    }
}
