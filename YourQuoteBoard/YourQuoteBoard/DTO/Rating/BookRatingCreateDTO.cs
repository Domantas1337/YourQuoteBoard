namespace YourQuoteBoard.DTO.Rating
{
    public class BookRatingCreateDTO
    {
        public double Rating { get; set; }
        public Guid BookId { get; set; }
    }
}
