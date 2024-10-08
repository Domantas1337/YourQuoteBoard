﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Enums;
using YourQuoteBoard.Entity.Books;
using YourQuoteBoard.Entity.Quotes;

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
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<QuoteSpecificRating> QuoteSpecificRatings { get; set; }
        public virtual DbSet<QuoteRatingSummary> QuoteRatingSummaries { get; set; }
        public virtual DbSet<BookSpecificRating> BookSpecificRatings { get; set; }
        public virtual DbSet<BookRatingSummary> BookRatingSummaries { get; set; }
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

                entity.HasMany(b => b.Tags)
                      .WithMany();

                entity.HasMany(q => q.RatingSummaries)
                      .WithOne(rs => rs.Quote)
                      .HasForeignKey(q => q.QuoteId)
                      .IsRequired();
            }
            );

            var defaultQuoteTags = Enum.GetValues(typeof(DefaultQuoteTags))
                .Cast<DefaultQuoteTags>()
                .Select(t => new Tag
                {
                    TagId = Guid.NewGuid(),
                    Name = t.ToString(),
                    IsDefault = true,
                    Discriminator = ItemType.Quote
                });

            modelBuilder.Entity<Tag>().HasData(defaultQuoteTags);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasMany(b => b.Quotes)
                    .WithOne(q => q.Book)
                    .HasForeignKey(q => q.BookId)
                    .IsRequired();


                entity.HasMany(b => b.Tags)
                      .WithMany();

                entity.HasMany(b => b.RatingSummaries)
                   .WithOne(rs => rs.Book)
                   .HasForeignKey(q => q.BookId)
                   .IsRequired();
            });

            var defaultBookTags = Enum.GetValues(typeof(DefaultBookTags))
                .Cast<DefaultBookTags>()
                .Select(t => new Tag
                {
                    TagId = Guid.NewGuid(),
                    Name = t.ToString(),
                    IsDefault = true,
                    Discriminator = ItemType.Book
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
                
                entity.HasMany(qr => qr.SpecificRatings)
                      .WithOne(sr => sr.BookRating)
                      .HasForeignKey(sr => sr.BookRatingId)
                      .IsRequired();

                });

            modelBuilder.Entity<QuoteRating>(entity =>
            {
                entity.HasKey(qr => qr.QuoteRatingId);

                entity.HasOne(qr => qr.Quote)
                      .WithMany(q => q.QuoteRatings)
                      .HasForeignKey(q => q.QuoteId)
                      .IsRequired();

                entity.HasMany(qr => qr.SpecificRatings)
                      .WithOne(sr => sr.QuoteRating)
                      .HasForeignKey(sr => sr.QuoteRatingId)
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

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasOne<Quote>()
                      .WithMany();

                entity.HasOne<ApplicationUser>()
                      .WithMany(u => u.Favorites);
            });
            
        }
    }
}
