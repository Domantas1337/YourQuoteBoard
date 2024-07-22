using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Enums;

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
        public virtual DbSet<QuoteRating> QuoteRatings { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<Tag> Tags { get ; set; }
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

                entity.HasMany(q => q.QuoteTags)
                .WithOne()
                .IsRequired(false);
            }
            );

            var defaultQuoteTags = Enum.GetValues(typeof(DefaultQuoteTags))
                .Cast<DefaultQuoteTags>()
                .Select(t => new Tag
                {
                    TagId = Guid.NewGuid(),
                    Name = t.ToString(),
                    IsDefault = true,
                    Discriminator = TagType.Quote
                });

            modelBuilder.Entity<Tag>().HasData(defaultQuoteTags);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasMany(b => b.Quotes)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId)
                .IsRequired();

                entity.HasMany(b => b.BookTags)
                .WithOne()
                .IsRequired(false);
            });

            var defaultBookTags = Enum.GetValues(typeof(DefaultBookTags))
                .Cast<DefaultBookTags>()
                .Select(t => new Tag
                {
                    TagId = Guid.NewGuid(),
                    Name = t.ToString(),
                    IsDefault = true,
                    Discriminator = TagType.Book
                });

            modelBuilder.Entity<Tag>().HasData(defaultBookTags);

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

            modelBuilder.Entity<QuoteRating>(entity =>
            {
                entity.HasKey(qr => qr.QuoteRatingId);

                entity.HasOne(qr => qr.Quote)
                      .WithMany(q => q.QuoteRatings)
                      .HasForeignKey(q => q.QuoteId)
                      .IsRequired();

                entity.HasOne<ApplicationUser>()
                      .WithMany(u => u.QuoteRatings)
                      .HasForeignKey(qr => qr.ApplicationUserId)
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
