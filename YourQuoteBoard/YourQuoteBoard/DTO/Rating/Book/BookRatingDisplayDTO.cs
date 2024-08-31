using YourQuoteBoard.Entity.Quotes;

namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookRatingDisplayDTO
    {
        public double OverallRating { get; set; }
        public required ICollection<BookSpecificRatingDTO> SpecificRatings { get; set; }
        public Guid BookId { get; set; }
    }
}
