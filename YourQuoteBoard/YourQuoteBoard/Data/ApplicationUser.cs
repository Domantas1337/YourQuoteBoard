using Microsoft.AspNetCore.Identity;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Quote>? Quotes { get; set; }
        public virtual ICollection<BookRating>? BookRatings { get; set; }
        public virtual ICollection<QuoteRating>? QuoteRatings { get; set; }

        public virtual ICollection<Folder>? Folders { get; set; }
    }

}