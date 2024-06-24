namespace YourQuoteBoard.DTO.Rating
{
    public class BookRatingForDirectUserInteractionDTO
    {
        public Guid BookRatingId { get; set; }
        public double Rating { get; set; }
        public Guid BookId { get; set; }
    }
}
