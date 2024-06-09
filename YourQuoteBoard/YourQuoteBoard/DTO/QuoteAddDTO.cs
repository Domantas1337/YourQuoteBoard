namespace YourQuoteBoard.DTO
{
    public class QuoteAddDTO
    {
        public string Title { get; set; } = "No title";
        public string Description { get; set; } = "No descroption";
        public required string Author { get; set; }
    }
}
