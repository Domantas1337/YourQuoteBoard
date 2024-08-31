using YourQuoteBoard.Entity.Quotes;

namespace YourQuoteBoard.Entity
{
    public class Folder
    {
        public Guid FolderId { get; set; }
        public string Name { get; set; } = "No name";
        public string Description { get; set; } = string.Empty;
        public int childQuotesCount { get; set; } = 0;
        public string ApplicationUserId { get; set; }
        public ICollection<Quote> Quotes { get; } = new List<Quote>();

        public void AddQuote(Quote quote)
        {
            Quotes.Add(quote);
        }
    }
}
