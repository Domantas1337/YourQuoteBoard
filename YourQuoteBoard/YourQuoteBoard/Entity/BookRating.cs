namespace YourQuoteBoard.Entity
{
    public class BookRating
    {
        public Guid BookRatingId { get; set; }
        public required double OverallRating { get; set; }
        public double? WritingStyleRating {  get; set; }
        public double? PlotRating { get; set; }
        public double? CharacterDevelopmentRating { get; set; }
        public double? WorldBuildingRating { get; set; }
        public double? AccuracyRating { get; set; }
        public required Guid BookId { get; set; }
        public Book Book { get; set; }
        public required string ApplicationUserId {  get; set; }
    }
}
