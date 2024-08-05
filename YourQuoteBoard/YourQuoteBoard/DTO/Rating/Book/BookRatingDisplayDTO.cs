namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookRatingDisplayDTO
    {
        public required BookRatingDTO BookRating { get; set; }
        public Guid BookId { get; set; }
    }
}
