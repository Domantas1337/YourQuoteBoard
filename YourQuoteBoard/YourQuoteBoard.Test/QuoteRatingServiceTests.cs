using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using YourQuoteBoard.Data;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Enums;
using YourQuoteBoard.Repositories;
using YourQuoteBoard.Services;

namespace YourQuoteBoard.Test
{
    public class QuoteRatingServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly Mock<DbSet<QuoteRating>> _mockQuoteRatingsDbSet;
        private readonly Mock<DbSet<Quote>> _mockQuoteDbSet;
        private readonly QuoteRatingRepository _quoteRatingRepository;
        private readonly QuoteRepository _quoteRepository;
        private readonly QuoteRatingService _quoteRatingService;
        public QuoteRatingServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            _mockQuoteRatingsDbSet = new Mock<DbSet<QuoteRating>>();
            _mockQuoteDbSet = new Mock<DbSet<Quote>>();

            _mockContext.Setup(m => m.QuoteRatings).Returns(_mockQuoteRatingsDbSet.Object);
            _mockContext.Setup(m => m.Quotes).Returns(_mockQuoteDbSet.Object);

            _quoteRatingRepository = new QuoteRatingRepository(_mockContext.Object);
            _quoteRepository = new QuoteRepository(_mockContext.Object);

            _quoteRatingService = new QuoteRatingService(_quoteRatingRepository, _quoteRepository, _mockMapper.Object);
        }


        [Theory]
        [InlineData(1.5)]
        [InlineData(10)]
        public void IsMultipleOfHalf_MultipleOfHalf_ReturnsTrue(double number)
        {
            Assert.True(_quoteRatingService.IsMultipleOfHalf(number));
        }


        [Theory]
        [InlineData(1.25)]
        [InlineData(10.1)]
        public void IsMultipleOfHalf_NotMultipleOfHalf_ReturnsFalse(double number)
        {
            Assert.True(!_quoteRatingService.IsMultipleOfHalf(number));
        }


        [Theory]
        [MemberData(nameof(GetValidRatings))]
        public void CheckIfValidRatingValue_ValidValues_ReturnsTrue(double overallRating, ICollection<QuoteSpecificRatingDTO> quoteSpecificRatings)
        {
            Assert.True(_quoteRatingService.CheckIfValidRatingValue(overallRating, quoteSpecificRatings));
        }


        [Theory]
        [MemberData(nameof(GetInvalidRatings))]
        public void CheckIfValidRatingValue_InvalidValues_ReturnsFalse(double overallRating, ICollection<QuoteSpecificRatingDTO> quoteSpecificRatings)
        {
            Assert.True(!_quoteRatingService.CheckIfValidRatingValue(overallRating, quoteSpecificRatings));
        }



        public static IEnumerable<object[]> GetValidRatings()
        {
            yield return new object[]
            {
                4.5,
                new List<QuoteSpecificRatingDTO>
                {
                    new QuoteSpecificRatingDTO
                    {
                        Rating = 4.5,
                        RatingCategory = QuoteRatingCategory.RelevanceToTheTopicRating
                    },
                    new QuoteSpecificRatingDTO
                    {
                        Rating = 2,
                        RatingCategory = QuoteRatingCategory.RelevanceToTheTopicRating
                    }
                }
            };
            yield return new object[]
            {
                2,
                new List<QuoteSpecificRatingDTO>
                {
                    new QuoteSpecificRatingDTO
                    {
                        Rating = 4.5,
                        RatingCategory = QuoteRatingCategory.InspirationalValueRating
                    },
                    new QuoteSpecificRatingDTO
                    {
                        Rating = 2,
                        RatingCategory = QuoteRatingCategory.OriginalityRating
                    }
                }
            };
        }

        public static IEnumerable<object[]> GetInvalidRatings()
        {
            yield return new object[]
            {
                4.25,
                new List<QuoteSpecificRatingDTO>
                {
                    new QuoteSpecificRatingDTO
                    {
                        Rating = 4.5,
                        RatingCategory = QuoteRatingCategory.RelevanceToTheTopicRating
                    },
                    new QuoteSpecificRatingDTO
                    {
                        Rating = 2,
                        RatingCategory = QuoteRatingCategory.RelevanceToTheTopicRating
                    }
                }
            };
            yield return new object[]
            {
                2,
                new List<QuoteSpecificRatingDTO>
                {
                    new QuoteSpecificRatingDTO
                    {
                        Rating = 4.5,
                        RatingCategory = QuoteRatingCategory.InspirationalValueRating
                    },
                    new QuoteSpecificRatingDTO
                    {
                        Rating = 2.1,
                        RatingCategory = QuoteRatingCategory.OriginalityRating
                    }
                }
            };
        }
    }
}