using YourQuoteBoard.DTO.Rating.Quote;

namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookRatingForDirectUserInteractionDTO
    {
        public Guid BookRatingId { get; set; }
        public double OverallRating { get; set; }
        public required ICollection<BookSpecificRatingDTO> SpecificRatings { get; set; }
        public Guid BookId { get; set; }
    }
}
