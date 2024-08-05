namespace YourQuoteBoard.DTO.Rating.Book
{
    public class BookRatingDTO
    {
        public double OverallRating { get; set; }
        public double? WritingStyleRating { get; set; }
        public double? PlotRating { get; set; }
        public double? CharacterDevelopmentRating { get; set; }
        public double? WorldBuildingRating { get; set; }
        public double? AccuracyRating { get; set; }
    }
}
