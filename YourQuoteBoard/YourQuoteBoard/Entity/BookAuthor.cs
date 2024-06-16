namespace YourQuoteBoard.Entity
{
    public class BookAuthor
    {
        public Guid BookAuthorId { get; set; }
        public string Name { get; set; } = "Unknown";
        public DateOnly Birthday { get; set; }
        public string Biography { get; set; } = String.Empty;
        public string PictureUrl { get; set; } = String.Empty;
    }
}
