namespace YourQuoteBoard.Entity
{
    public class Favorite
    {
        public Guid FavoriteId { get; set; }
        public required string ApplicationUserId { get; set; }
        public required Guid QuoteId { get; set; }
        public DateTime TimeAdded { get; set; }
    }
}
