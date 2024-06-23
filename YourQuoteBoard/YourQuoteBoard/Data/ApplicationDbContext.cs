using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        { 
        }

        public virtual DbSet<Quote>? Quotes { get; set; }
        public virtual DbSet<Book>? Books { get; set; }
        public virtual DbSet<BookRating> BookRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quote>()
                .HasOne(q => q.ApplicationUser)
                .WithMany(u => u.Quotes)
                .HasForeignKey(q => q.ApplicationUserId)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Quotes)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId)
                .IsRequired(false);

            modelBuilder.Entity<BookRating>(entity =>
            {
                entity.HasKey(br => br.BookRatingId);

                entity.HasOne(br => br.Book)
                      .WithMany(b => b.BookRatings)
                      .HasForeignKey(br => br.BookId)
                      .IsRequired();

                entity.HasOne<ApplicationUser>()
                      .WithMany(u => u.BookRatings)
                      .HasForeignKey(br => br.ApplicationUserId)
                      .IsRequired();
            });
            
        }
    }
}
