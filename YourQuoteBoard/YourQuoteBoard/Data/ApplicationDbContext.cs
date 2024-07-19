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
        public virtual DbSet<Folder> Folders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quote>( entity =>
            {
                entity.HasKey(e => e.QuoteId);

                entity.HasOne(q => q.ApplicationUser)
                .WithMany(u => u.Quotes)
                .HasForeignKey(q => q.ApplicationUserId)
                .IsRequired();
            }
            );

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Quotes)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId)
                .IsRequired();

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

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.HasKey(br => br.FolderId);

                entity.HasOne<ApplicationUser>()
                      .WithMany(e => e.Folders)
                      .HasForeignKey(e => e.ApplicationUserId)
                      .IsRequired();

                entity.HasMany(e => e.Quotes)
                      .WithMany(e => e.Folders)
                      .UsingEntity("QuoteFolderJointTable");

            });
            
        }
    }
}
