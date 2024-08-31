using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity.Books
{
    public class BookRating
    {
        public Guid BookRatingId { get; set; }
        public double OverallRating { get; set; }
        public ICollection<BookSpecificRating> SpecificRatings { get; } = new List<BookSpecificRating>();
        public Guid BookId { get; set; }
        public required Book Book { get; set; }
        public required string ApplicationUserId { get; set; }

        public void AddSpecificRatings(ICollection<BookSpecificRatingDTO>? specRatings)
        {
            if (specRatings == null) return;

            foreach (var specRating in specRatings)
            {
                this.SpecificRatings.Add(
                    new BookSpecificRating
                    {
                        Rating = specRating.Rating,
                        RatingCategory = specRating.RatingCategory
                    }
                    );
            }
        }
    }
}
