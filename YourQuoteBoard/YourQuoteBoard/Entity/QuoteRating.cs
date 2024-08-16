using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity
{
    public class QuoteRating
    {
        public Guid QuoteRatingId { get; set; }
        public double OverallRating { get; set; }
        public ICollection<SpecificRating> SpecificRatings { get; } = new List<SpecificRating>();
        public Guid QuoteId { get; set; }
        public required Quote Quote { get; set; }
        public required string ApplicationUserId { get; set; }
    
        public void AddSpecificRatings(ICollection<SpecificRating>? specRatings)
        {
            if (specRatings == null) return;

            for (int i = 0; i < specRatings.Count; ++i)
            {
                this.SpecificRatings.Add(specRatings.ElementAt(i));
            }
        }
    }
}
