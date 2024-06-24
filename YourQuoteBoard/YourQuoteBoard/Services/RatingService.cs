using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Services
{
    public class RatingService(IRatingRepository _ratingRepository, IBookRepository _bookRepository, IMapper _mapper) : IRatingService
    {
        public async Task<BookRatingForDirectUserInteractionDTO> AddBookRatingAsync(BookRatingForDirectUserInteractionDTO rating, string userId)
        {
            BookRating bookRating = _mapper.Map<BookRating>(rating, opts =>
            {
                opts.Items["userId"] = userId;
            });
            BookRating addedBookRating = await _ratingRepository.AddBookRatingAsync(bookRating, userId);

            Book book = await _bookRepository.UpdateBookRatingWhenARatingHasBeenAdded(rating.BookId, rating.Rating);

            return _mapper.Map<BookRatingForDirectUserInteractionDTO>(addedBookRating);
        }

        public async Task<List<BookRatingDisplayDTO>> GetAllBookRatingsAsync()
        {
            List<BookRating> bookRatings = await _ratingRepository.GetAllBookRatingsAsync();
            List<BookRatingDisplayDTO> bookRatingDTOs = _mapper.Map<List<BookRatingDisplayDTO>>(bookRatings);
        
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
                return _mapper.Map<BookRatingForDirectUserInteractionDTO>(bookRating);
            }            
        }

        public async Task<List<BookRatingDisplayDTO>> GetRatingsForBookAsync(Guid bookId)
        {
            List<BookRating> bookRatings = await _ratingRepository.GetRatingsForBookAsync(bookId);
            List<BookRatingDisplayDTO> bookRatingDTOs = _mapper.Map<List<BookRatingDisplayDTO>>(bookRatings);

            return bookRatingDTOs;
        }

        public async Task<BookRatingForUpdateDTO> UpdateBookRatingAsync(BookRatingForUpdateDTO bookRatingDTO)
        {
            BookRating bookRatingToUpdate = _mapper.Map<BookRating>(bookRatingDTO, opts =>
            {
                opts.Items["newRating"] = bookRatingDTO.NewRating;
            }); 
            BookRating? bookRating = await _ratingRepository.UpdateBookRatingAsync(bookRatingToUpdate);

            Book book = await _bookRepository.UpdateBookRatingWhenARatingHasBeenUpdated(bookRatingDTO.BookId, bookRatingDTO.PreviousRating, bookRatingDTO.NewRating);

            return bookRatingDTO;
        }
    }
}
