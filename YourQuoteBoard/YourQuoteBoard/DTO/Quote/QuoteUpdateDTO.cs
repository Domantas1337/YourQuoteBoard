namespace YourQuoteBoard.DTO.Quote
{
    public class QuoteUpdateDTO
    {
        public required Guid QuoteId { get; set; }
        public string Title { get; set; } = "No title";
        public string Description { get; set; } = "No descroption";
        public required string Author { get; set; }
        public required Guid BookId { get; set; }
        public ICollection<Guid> TagIds { get; set; } = new HashSet<Guid>();
    }
}
