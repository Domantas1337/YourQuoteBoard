namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookRatingCreateDTO
    {
        public required BookRatingDTO BookRating { get; set; }
        public Guid BookId { get; set; }
    }
}
