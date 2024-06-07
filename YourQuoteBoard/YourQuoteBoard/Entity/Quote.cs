using Microsoft.EntityFrameworkCore;

namespace YourQuoteBoard.Entity
{
    public class Quote
    {
        public Guid QuoteId { get; set; }
        public string Title { get; set; } = "No title";
        public string Description { get; set; } = "No descroption";
        public required string Author { get; set; }
        public DateTime Created { get; set; }
    }
}
