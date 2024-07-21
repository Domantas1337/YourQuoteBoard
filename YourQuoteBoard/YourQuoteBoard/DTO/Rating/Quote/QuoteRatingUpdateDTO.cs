namespace YourQuoteBoard.DTO.Rating.Quote
{
    public class QuoteRatingUpdateDTO
    {
        public Guid QuoteRatingId { get; set; }
        public double PreviousRating { get; set; }
        public double NewRating { get; set; }
        public Guid QuoteId { get; set; }
    }
}
