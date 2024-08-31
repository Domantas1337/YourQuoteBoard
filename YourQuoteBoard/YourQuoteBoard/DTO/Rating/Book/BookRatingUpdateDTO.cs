using YourQuoteBoard.DTO.Rating.Quote;

namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookRatingUpdateDTO
    {
        public Guid BookRatingId { get; set; }
        public required double OverallRating { get; set; }
        public ICollection<BookSpecificRatingDTO> SpecificRatings { get; set; }
        public Guid BookId { get; set; }
    }
}
