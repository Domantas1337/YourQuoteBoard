using System.ComponentModel.DataAnnotations.Schema;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Interfaces;

namespace YourQuoteBoard.Entity.Books
{
    public class Book : IRatable
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string CoverImagePath { get; set; }
        public ICollection<Quote> Quotes { get; } = new List<Quote>();
        public ICollection<Tag> Tags { get; } = new List<Tag>();
        public double AverageOverallRating { get; set; }
        public int NumberOfOverallRatings { get; set; }
        public ICollection<BookRating> BookRatings { get; } = new List<BookRating>();
        public ICollection<BookRatingSummary> RatingSummaries { get; } = new List<BookRatingSummary>();

        [NotMapped]
        public IFormFile CoverImage { get; set; }


        public void AddTags(ICollection<Tag> tags)
        {
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }
        }

        public void AddRatingSummary(BookSpecificRatingDTO specificRating)
        {
            if (specificRating != null)
            {
                BookRatingSummary ratingSummary = new BookRatingSummary()
                {
                    RatingCategory = specificRating.RatingCategory,
                    AverageRating = (double)specificRating.Rating,
                    NumberOfRatings = 1
                };
                RatingSummaries.Add(ratingSummary);
            }
        }
    }
}
