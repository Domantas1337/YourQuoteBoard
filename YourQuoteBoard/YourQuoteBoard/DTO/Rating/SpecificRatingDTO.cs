using YourQuoteBoard.Enums;

namespace YourQuoteBoard.DTO.Rating
{
    public class SpecificRatingDTO
    {
        public Guid SpecificRatingId { get; set; }
        public double Rating { get; set; }
        public RatingCategory RatingCategory { get; set; }  
    }
}
