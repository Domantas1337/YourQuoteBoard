using AutoMapper;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Services
{
    public class RatingService(IRatingRepository _ratingRepository, IMapper _mapper) : IRatingService
    {
        public async Task<BookRatingUpdateDTO> AddBookRatingAsync(BookRatingDTO rating, string userId)
        {
            BookRating bookRating = _mapper.Map<BookRating>(rating, opts =>
            {
                opts.Items["userId"] = userId;
            });
            BookRating addedBookRating = await _ratingRepository.AddBookRatingAsync(bookRating, userId);

            return _mapper.Map<BookRatingUpdateDTO>(addedBookRating);
        }

        public async Task<List<BookRatingDTO>> GetAllBookRatingsAsync()
        {
            List<BookRating> bookRatings = await _ratingRepository.GetAllBookRatingsAsync();
            List<BookRatingDTO> bookRatingDTOs = _mapper.Map<List<BookRatingDTO>>(bookRatings);
        
            return bookRatingDTOs;
        }

        public async Task<BookRatingUpdateDTO?> GetBookRatingByUserAsync(string userId, Guid bookId)
        {
            BookRating? bookRating = await _ratingRepository.GetBookRatingByUserAsync(userId, bookId);
            
            if (bookRating == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<BookRatingUpdateDTO>(bookRating);
            }            
        }

        public async Task<List<BookRatingDTO>> GetRatingsForBookAsync(Guid bookId)
        {
            List<BookRating> bookRatings = await _ratingRepository.GetRatingsForBookAsync(bookId);
            List<BookRatingDTO> bookRatingDTOs = _mapper.Map<List<BookRatingDTO>>(bookRatings);

            return bookRatingDTOs;
        }

        public async Task<BookRatingUpdateDTO> UpdateBookRatingAsync(BookRatingUpdateDTO bookRatingDTO)
        {
            BookRating bookRatingToUpdate = _mapper.Map<BookRating>(bookRatingDTO);
            BookRating? bookRating = await _ratingRepository.UpdateBookRatingAsync(bookRatingToUpdate);

            return bookRatingDTO;
        }
    }
}
