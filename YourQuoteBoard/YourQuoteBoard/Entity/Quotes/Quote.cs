using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using YourQuoteBoard.Data;
using YourQuoteBoard.Enums;
using YourQuoteBoard.Entity.Books;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Interfaces;

namespace YourQuoteBoard.Entity.Quotes
{
    public class Quote : IRatable
    {
        public Guid QuoteId { get; set; }
        public string Title { get; set; } = "No title";
        public string Description { get; set; } = "No descroption";
        public string ShortDescription { get; set; } = string.Empty;
        public required string Author { get; set; }
        public DateTime Created { get; set; }
        public required Guid BookId { get; set; }
        public required Book Book { get; set; }
        public List<Folder> Folders { get; set; } = new List<Folder> { };
        public double AverageOverallRating { get; set; }
        public int NumberOfOverallRatings { get; set; }
        public ICollection<QuoteRating> QuoteRatings { get; } = new List<QuoteRating>();
        public ICollection<QuoteRatingSummary> RatingSummaries { get; } = new List<QuoteRatingSummary>();
        public ICollection<Tag> Tags { get; } = new List<Tag>();
        public Genre? Genre { get; set; }

        [Required]
        public required string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public void AddTags(ICollection<Tag> tags)
        {
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }
        }

        public void AddRatingSummary(QuoteSpecificRatingDTO specificRating)
        {

            if (specificRating.Rating != null)
            {
                QuoteRatingSummary ratingSummary = new QuoteRatingSummary()
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
