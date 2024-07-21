﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourQuoteBoard.Data;

#nullable disable

namespace YourQuoteBoard.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240721220146_quotebookratingupdate")]
    partial class quotebookratingupdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QuoteFolderJointTable", b =>
                {
                    b.Property<Guid>("FoldersFolderId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("QuotesQuoteId")
                        .HasColumnType("TEXT");

                    b.HasKey("FoldersFolderId", "QuotesQuoteId");

                    b.HasIndex("QuotesQuoteId");

                    b.ToTable("QuoteFolderJointTable");
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("AverageRating")
                        .HasColumnType("REAL");

                    b.Property<string>("CoverImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("NumberOfRatings")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pages")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.BookRating", b =>
                {
                    b.Property<Guid>("BookRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double?>("AccuracyRating")
                        .HasColumnType("REAL");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<double?>("CharacterDevelopmentRating")
                        .HasColumnType("REAL");

                    b.Property<double?>("OverallRating")
                        .HasColumnType("REAL");

                    b.Property<double?>("PlotRating")
                        .HasColumnType("REAL");

                    b.Property<double?>("WorldBuildingRating")
                        .HasColumnType("REAL");

                    b.Property<double?>("WritingStyleRating")
                        .HasColumnType("REAL");

                    b.HasKey("BookRatingId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BookId");

                    b.ToTable("BookRatings");
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.Folder", b =>
                {
                    b.Property<Guid>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("childQuotesCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("FolderId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.Quote", b =>
                {
                    b.Property<Guid>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("AverageRating")
                        .HasColumnType("REAL");

                    b.Property<Guid>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("NumberOfRatings")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("QuoteId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BookId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.QuoteRating", b =>
                {
                    b.Property<Guid>("QuoteRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("InspirationalValueRating")
                        .HasColumnType("REAL");

                    b.Property<double>("OriginalityRating")
                        .HasColumnType("REAL");

                    b.Property<double>("OverallRating")
                        .HasColumnType("REAL");

                    b.Property<Guid>("QuoteId")
                        .HasColumnType("TEXT");

                    b.Property<double>("RelevanceToTheTopicRating")
                        .HasColumnType("REAL");

                    b.HasKey("QuoteRatingId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("QuoteId");

                    b.ToTable("QuoteRatings");
                });

            modelBuilder.Entity("YourQuoteBoard.Data.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuoteFolderJointTable", b =>
                {
                    b.HasOne("YourQuoteBoard.Entity.Folder", null)
                        .WithMany()
                        .HasForeignKey("FoldersFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourQuoteBoard.Entity.Quote", null)
                        .WithMany()
                        .HasForeignKey("QuotesQuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.BookRating", b =>
                {
                    b.HasOne("YourQuoteBoard.Data.ApplicationUser", null)
                        .WithMany("BookRatings")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourQuoteBoard.Entity.Book", "Book")
                        .WithMany("BookRatings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.Folder", b =>
                {
                    b.HasOne("YourQuoteBoard.Data.ApplicationUser", null)
                        .WithMany("Folders")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.Quote", b =>
                {
                    b.HasOne("YourQuoteBoard.Data.ApplicationUser", "ApplicationUser")
                        .WithMany("Quotes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourQuoteBoard.Entity.Book", "Book")
                        .WithMany("Quotes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.QuoteRating", b =>
                {
                    b.HasOne("YourQuoteBoard.Data.ApplicationUser", null)
                        .WithMany("QuoteRatings")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourQuoteBoard.Entity.Quote", "Quote")
                        .WithMany("QuoteRatings")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.Book", b =>
                {
                    b.Navigation("BookRatings");

                    b.Navigation("Quotes");
                });

            modelBuilder.Entity("YourQuoteBoard.Entity.Quote", b =>
                {
                    b.Navigation("QuoteRatings");
                });

            modelBuilder.Entity("YourQuoteBoard.Data.ApplicationUser", b =>
                {
                    b.Navigation("BookRatings");

                    b.Navigation("Folders");

                    b.Navigation("QuoteRatings");

                    b.Navigation("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}
