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
    [Migration("20240725195026_favorites")]
    partial class favorites
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("BookTag", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TagsTagId")
                        .HasColumnType("TEXT");

                    b.HasKey("BookId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("BookTag");
                });

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

            modelBuilder.Entity("QuoteTag", b =>
                {
                    b.Property<Guid>("QuoteId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TagsTagId")
                        .HasColumnType("TEXT");

                    b.HasKey("QuoteId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("QuoteTag");
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

            modelBuilder.Entity("YourQuoteBoard.Entity.Favorite", b =>
                {
                    b.Property<Guid>("FavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("QuoteId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeAdded")
                        .HasColumnType("TEXT");

                    b.HasKey("FavoriteId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("QuoteId");

                    b.ToTable("Favorites");
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

            modelBuilder.Entity("YourQuoteBoard.Entity.Tag", b =>
                {
                    b.Property<Guid>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Discriminator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagId = new Guid("0d674a4b-49a7-4c0b-96e7-e7bf5413d2b0"),
                            Discriminator = 0,
                            IsDefault = true,
                            Name = "Inspirational"
                        },
                        new
                        {
                            TagId = new Guid("bdb73fad-f09b-4ccf-96df-d0c5e189f406"),
                            Discriminator = 0,
                            IsDefault = true,
                            Name = "Funny"
                        },
                        new
                        {
                            TagId = new Guid("a880914c-4f7b-44ff-a5fe-3a4119c16968"),
                            Discriminator = 0,
                            IsDefault = true,
                            Name = "Philosophical"
                        },
                        new
                        {
                            TagId = new Guid("678d270d-2c89-46cd-86d6-6b9d7ffac6f2"),
                            Discriminator = 0,
                            IsDefault = true,
                            Name = "Literary"
                        },
                        new
                        {
                            TagId = new Guid("403935a2-5de1-4746-8069-0299b879626d"),
                            Discriminator = 0,
                            IsDefault = true,
                            Name = "Sad"
                        },
                        new
                        {
                            TagId = new Guid("f05d5d2d-8e38-4114-85ab-f5f548e38009"),
                            Discriminator = 0,
                            IsDefault = true,
                            Name = "Emotional"
                        },
                        new
                        {
                            TagId = new Guid("d0a1cf93-3714-47b1-a56a-a5a15857fc3e"),
                            Discriminator = 0,
                            IsDefault = true,
                            Name = "Informative"
                        },
                        new
                        {
                            TagId = new Guid("8433df0c-42a4-42af-9636-af2fd8befa7f"),
                            Discriminator = 1,
                            IsDefault = true,
                            Name = "Biography"
                        },
                        new
                        {
                            TagId = new Guid("87b776b6-1898-4fd4-a189-8dea3fb2e556"),
                            Discriminator = 1,
                            IsDefault = true,
                            Name = "Fiction"
                        },
                        new
                        {
                            TagId = new Guid("1f73aea4-c285-4bc1-a6b9-5598ed711eed"),
                            Discriminator = 1,
                            IsDefault = true,
                            Name = "Autobiography"
                        },
                        new
                        {
                            TagId = new Guid("aa1067dc-5728-4bf2-97d2-ed5cc3eec9e9"),
                            Discriminator = 1,
                            IsDefault = true,
                            Name = "Novel"
                        },
                        new
                        {
                            TagId = new Guid("0b3141db-f2d0-4b00-b503-778d657ebff9"),
                            Discriminator = 1,
                            IsDefault = true,
                            Name = "Romantic"
                        },
                        new
                        {
                            TagId = new Guid("866a5a7b-2c4b-4288-b4c5-28bf1e549e85"),
                            Discriminator = 1,
                            IsDefault = true,
                            Name = "Non_Fiction"
                        },
                        new
                        {
                            TagId = new Guid("a2a62cbe-642c-4925-9547-57d3d1ae1a36"),
                            Discriminator = 1,
                            IsDefault = true,
                            Name = "Comedy"
                        });
                });

            modelBuilder.Entity("YourQuoteBoard.Data.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("BookTag", b =>
                {
                    b.HasOne("YourQuoteBoard.Entity.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourQuoteBoard.Entity.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("QuoteTag", b =>
                {
                    b.HasOne("YourQuoteBoard.Entity.Quote", null)
                        .WithMany()
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourQuoteBoard.Entity.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
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

            modelBuilder.Entity("YourQuoteBoard.Entity.Favorite", b =>
                {
                    b.HasOne("YourQuoteBoard.Data.ApplicationUser", null)
                        .WithMany("Favorites")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourQuoteBoard.Entity.Quote", null)
                        .WithMany()
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

                    b.Navigation("Favorites");

                    b.Navigation("Folders");

                    b.Navigation("QuoteRatings");

                    b.Navigation("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}
