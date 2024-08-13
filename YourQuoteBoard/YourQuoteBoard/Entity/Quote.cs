using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using YourQuoteBoard.Data;
using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Entity
{
    public class Quote
    {
        public Guid QuoteId { get; set; }
        public string Title { get; set; } = "No title";
        public string Description { get; set; } = "No descroption";
        public string ShortDescription { get; set; } = String.Empty;
        public required string Author { get; set; }
        public DateTime Created { get; set; }
        public required Guid BookId {get; set;}
        public required Book Book { get; set; }
        public List<Folder> Folders { get; set; } = new List<Folder> { };
        public ICollection<QuoteRating> QuoteRatings { get; } = new List<QuoteRating>();
        public double? AverageRating { get; set; }
        public int? NumberOfRatings { get; set; }
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
    }
}
