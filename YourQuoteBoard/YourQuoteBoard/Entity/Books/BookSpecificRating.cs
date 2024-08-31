using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity.Books
{
    public class BookSpecificRating
    {
        public Guid BookSpecificRatingId { get; set; }
        public BookRatingCategory RatingCategory { get; set; }
        public double? Rating { get; set; }
        public Guid BookRatingId { get; set; }
        public BookRating BookRating { get; set; }
    }
}
