namespace YourQuoteBoard.DTO.Quote
{
    public class QuoteAddDTO
    {
        public string Title { get; set; } = "No title";
        public string Description { get; set; } = "No descroption";
        public required string Author { get; set; }
        public required Guid bookId { get; set; }
        public ICollection<Guid> TagIds { get; set; }
    }
}
