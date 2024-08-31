using YourQuoteBoard.Entity.Books;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity
{
    public class BookRatingSummary
    {
        public Guid BookRatingSummaryId { get; set; }
        public BookRatingCategory RatingCategory { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
