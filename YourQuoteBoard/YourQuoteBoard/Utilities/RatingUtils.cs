using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Interfaces;

namespace YourQuoteBoard.Utilities
{
    public static class RatingUtils
    {
        public static void UpdateOverallRatingWhenAdded<T>(T item, double overallRating) where T : IRatable
        {
            double currentTotalRating = item.AverageOverallRating * item.NumberOfOverallRatings;
            item.NumberOfOverallRatings += 1;
            item.AverageOverallRating = (currentTotalRating + overallRating) / item.NumberOfOverallRatings;
        }

        public static void UpdateOverallRatingWhenUpdated<T>(T item, double currentOverallRating, double newOverallRating) where T : IRatable
        {
            double currentTotalRating = item.AverageOverallRating * item.NumberOfOverallRatings;
            currentTotalRating = (currentTotalRating - currentOverallRating) + newOverallRating;
            item.AverageOverallRating = currentTotalRating / item.NumberOfOverallRatings;
        }
    }
}
