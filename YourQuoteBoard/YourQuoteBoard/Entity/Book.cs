using System.ComponentModel.DataAnnotations.Schema;

namespace YourQuoteBoard.Entity
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string CoverImagePath { get; set; }
        public ICollection<Quote> Quotes { get; } = new List<Quote>();
        public ICollection<BookRating> BookRatings { get; } = new List<BookRating>();

        [NotMapped]
        public IFormFile CoverImage { get; set; }
    }
}
