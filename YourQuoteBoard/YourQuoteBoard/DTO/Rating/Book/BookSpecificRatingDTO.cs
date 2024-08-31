using YourQuoteBoard.Enums;

namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookSpecificRatingDTO
    {
        public Guid BookSpecificRatingId { get; set; }
        public double Rating { get; set; }
        public BookRatingCategory RatingCategory { get; set; }
    }
}
