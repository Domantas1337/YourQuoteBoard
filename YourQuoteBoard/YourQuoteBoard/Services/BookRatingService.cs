using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Services
{
    public class BookRatingService(IBookRatingRepository _ratingRepository, IBookRepository _bookRepository, IMapper _mapper) : IBookRatingService
    {
        public async Task<BookRatingCreateDTO> AddBookRatingAsync(BookRatingCreateDTO rating, string userId)
        {
            BookRating bookRating = new BookRating { 
                ApplicationUserId = userId,
                AccuracyRating = rating.BookRating.AccuracyRating,
                CharacterDevelopmentRating = rating.BookRating.CharacterDevelopmentRating,
                OverallRating = rating.BookRating.OverallRating,
                PlotRating = rating.BookRating.PlotRating,
                WorldBuildingRating = rating.BookRating.WorldBuildingRating,
                WritingStyleRating = rating.BookRating.WritingStyleRating,
                BookId = rating.BookId
            };

            BookRating addedBookRating = await _ratingRepository.AddBookRatingAsync(bookRating, userId);

            Book book = await _bookRepository.UpdateBookRatingWhenARatingHasBeenAdded(rating.BookId, rating.BookRating);

            return _mapper.Map<BookRatingCreateDTO>(addedBookRating);
        }

        public async Task<List<BookRatingDisplayDTO>> GetAllBookRatingsAsync()
        {
            List<BookRating> bookRatings = await _ratingRepository.GetAllBookRatingsAsync();

            List<BookRatingDisplayDTO> bookRatingDTOs = bookRatings.Select(br => new BookRatingDisplayDTO
            {
                BookRating = new BookRatingDTO
                {
                    AccuracyRating = br.AccuracyRating,
                    CharacterDevelopmentRating = br.CharacterDevelopmentRating,
                    OverallRating = br.OverallRating,
                    PlotRating = br.PlotRating,
                    WorldBuildingRating = br.WorldBuildingRating,
                    WritingStyleRating = br.WritingStyleRating,
                },
                BookId = br.BookId,
            }).ToList();


            return bookRatingDTOs;
        }

        public async Task<BookRatingForDirectUserInteractionDTO?> GetBookRatingByUserAsync(string userId, Guid bookId)
        {
            BookRating? bookRating = await _ratingRepository.GetBookRatingByUserAsync(userId, bookId);
            
            if (bookRating == null)
            {
                return null;
            }
            else
            {
                BookRatingForDirectUserInteractionDTO rating = new BookRatingForDirectUserInteractionDTO
                {
                    BookRatingId = bookRating.BookRatingId,
                    BookRating = new BookRatingDTO
                    {
                        OverallRating = bookRating.OverallRating,
                        AccuracyRating = bookRating.AccuracyRating,
                        CharacterDevelopmentRating = bookRating.CharacterDevelopmentRating,
                        PlotRating = bookRating.PlotRating,
                        WorldBuildingRating = bookRating.WorldBuildingRating,
                        WritingStyleRating = bookRating.WritingStyleRating
                    },
                    BookId = bookRating.BookId
                };

                return rating;
            }            
        }

        public async Task<List<BookRatingDisplayDTO>> GetRatingsForBookAsync(Guid bookId)
        {
            List<BookRating> bookRatings = await _ratingRepository.GetRatingsForBookAsync(bookId);
            List<BookRatingDisplayDTO> bookRatingDTOs = bookRatings.Select(br => new BookRatingDisplayDTO
            {
                BookRating = new BookRatingDTO
                {
                    AccuracyRating = br.AccuracyRating,
                    CharacterDevelopmentRating = br.CharacterDevelopmentRating,
                    OverallRating = br.OverallRating,
                    PlotRating = br.PlotRating,
                    WorldBuildingRating = br.WorldBuildingRating,
                    WritingStyleRating = br.WritingStyleRating,
                },
                BookId = br.BookId,
            }).ToList();


            return bookRatingDTOs;
        }

        public async Task<BookRatingForUpdateDTO> UpdateBookRatingAsync(BookRatingForUpdateDTO bookRatingDTO, string userId)
        {
            BookRating bookRatingToUpdate = new BookRating
            {
                ApplicationUserId = userId,
                BookRatingId = bookRatingDTO.BookRatingId,
                BookId = bookRatingDTO.BookId,
                OverallRating = bookRatingDTO.NewRating.OverallRating,
                AccuracyRating = bookRatingDTO.NewRating.AccuracyRating,
                PlotRating = bookRatingDTO.NewRating.PlotRating,
                CharacterDevelopmentRating = bookRatingDTO.NewRating.CharacterDevelopmentRating,
                WorldBuildingRating = bookRatingDTO.NewRating.WorldBuildingRating,
                WritingStyleRating = bookRatingDTO.NewRating.WorldBuildingRating
            };

            BookRating? bookRating = await _ratingRepository.UpdateBookRatingAsync(bookRatingToUpdate);
            Book book = await _bookRepository.UpdateBookRatingWhenARatingHasBeenUpdated(bookRatingDTO.BookId, bookRatingDTO.CurrentRating, bookRatingDTO.NewRating);

            return bookRatingDTO;
        }
    }
}
