namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookRatingForUpdateDTO
    {
        public Guid BookRatingId { get; set; }
        public BookRatingDTO CurrentRating { get; set; }
        public BookRatingDTO NewRating { get; set; }
        public Guid BookId { get; set; }
    }
}
