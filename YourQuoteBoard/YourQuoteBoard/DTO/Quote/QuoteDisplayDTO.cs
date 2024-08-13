namespace YourQuoteBoard.DTO
{
    public class QuoteDisplayDTO
    {
        public Guid QuoteId { get; set; }
        public string Title { get; set; } = "No title";
        public string ShortDescription { get; set; } = String.Empty;
        public double? AverageRating { get; set; }
    }
}
