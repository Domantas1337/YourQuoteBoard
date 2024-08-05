namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookRatingForDirectUserInteractionDTO
    {
        public Guid BookRatingId { get; set; }
        public BookRatingDTO BookRating { get; set; }
        public Guid BookId { get; set; }
    }
}
