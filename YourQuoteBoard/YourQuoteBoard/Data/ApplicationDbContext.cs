using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        { 
        }

        public virtual DbSet<Quote>? Quotes { get; set; }
    }
}
