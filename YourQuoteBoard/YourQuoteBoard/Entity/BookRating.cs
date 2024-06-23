namespace YourQuoteBoard.Entity
{
    public class BookRating
    {
        public Guid BookRatingId { get; set; }
        public double Rating { get; set; }
        public Guid BookId { get; set; }
        public required Book Book { get; set; }
        public required string ApplicationUserId {  get; set; }
    }
}
