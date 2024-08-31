using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Entity.Books;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;
using YourQuoteBoard.Repositories;
using YourQuoteBoard.Utilities;

namespace YourQuoteBoard.Services
{
    public class BookRatingService(IBookRatingRepository _ratingRepository, IBookRepository _bookRepository, IMapper _mapper) : IBookRatingService
    {
        public async Task AddBookRatingAsync(BookRatingCreateDTO rating, string userId)
        {
            Book book = await _bookRepository.GetBookByIdAsync(rating.BookId);

            RatingUtils.UpdateOverallRatingWhenAdded<Book>(book, rating.OverallRating);
            UpdateSpecificRatingWhenAdded(book, rating.SpecificRatings);


            await _bookRepository.SaveAsync();

            BookRating bookRating = new BookRating 
            { 
                ApplicationUserId = userId, 
                Book = book,
                OverallRating = rating.OverallRating
            };

            bookRating.AddSpecificRatings((ICollection<BookSpecificRatingDTO>?) rating.SpecificRatings);

            await _ratingRepository.AddBookRatingAsync(bookRating, userId);
        }

        public async Task<List<BookRatingDisplayDTO>> GetAllBookRatingsAsync()
        {
            List<BookRating> bookRatings = await _ratingRepository.GetAllBookRatingsAsync();

            List<BookRatingDisplayDTO> bookRatingDTOs = bookRatings.Select(br => new BookRatingDisplayDTO
            {
                OverallRating = br.OverallRating,
                SpecificRatings = _mapper.Map<List<BookSpecificRatingDTO>>(br.SpecificRatings),
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
                    SpecificRatings = _mapper.Map<List<BookSpecificRatingDTO>>(bookRating.SpecificRatings),
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
                OverallRating = br.OverallRating,
                SpecificRatings = _mapper.Map<List<BookSpecificRatingDTO>>(br.SpecificRatings),
                BookId = br.BookId,
            }).ToList();

            return bookRatingDTOs;
        }

        public async Task<BookRatingUpdateDTO> UpdateBookRatingAsync(BookRatingUpdateDTO bookRatingDTO, string userId)
        {
            BookRating? currentBookRating = await _ratingRepository.GetBookRatingByIdAsync(bookRatingDTO.BookRatingId);
            Book book = await _bookRepository.GetByIdForRatingAsync(bookRatingDTO.BookId);

            RatingUtils.UpdateOverallRatingWhenUpdated<Book>(book, currentBookRating.OverallRating, bookRatingDTO.OverallRating);
            UpdateSpecificRatings(book, currentBookRating.SpecificRatings, bookRatingDTO.SpecificRatings);
            await _bookRepository.SaveAsync();

            currentBookRating.OverallRating = bookRatingDTO.OverallRating;
            await _bookRepository.SaveAsync();

            return bookRatingDTO;
        }


        private void UpdateSpecificRatingWhenAdded(Book book, ICollection<BookSpecificRatingDTO> specificRatings)
        {
            var ratingSummaryDict = book.RatingSummaries
                                    .ToDictionary(summary => summary.RatingCategory);
            foreach (BookSpecificRatingDTO rating in specificRatings)
            {
                if (ratingSummaryDict.TryGetValue(rating.RatingCategory, out var summary))
                {
                    double currentTotal = summary.AverageRating * summary.NumberOfRatings;
                    currentTotal += (double)rating.Rating;
                    summary.NumberOfRatings += 1;
                    summary.AverageRating = currentTotal / summary.NumberOfRatings;
                }
                else
                {
                    book.AddRatingSummary(rating);
                }
            }
        }


        public void UpdateSpecificRatings(Book book,
                                          ICollection<BookSpecificRating> currentRatings,
                                          ICollection<BookSpecificRatingDTO> newRatings
                                          )
        {
            var currentRatingDictionary = currentRatings.ToDictionary(sr => sr.RatingCategory);
            var currentSummaryDictionary = book.RatingSummaries.ToDictionary(sr => sr.RatingCategory);

            foreach (BookSpecificRatingDTO newRating in newRatings)
            {
                if (currentRatingDictionary.TryGetValue(newRating.RatingCategory, out var currentRating))
                {
                    BookRatingSummary ratingSummary = currentSummaryDictionary.GetValueOrDefault(newRating.RatingCategory);
                    double currentTotal = ratingSummary.AverageRating * ratingSummary.NumberOfRatings;
                    ratingSummary.AverageRating = (currentTotal - (double)currentRating.Rating) + (double)newRating.Rating;

                    currentRating.Rating = newRating.Rating;
                }
                else if (newRating.Rating != null)
                {
                    book.AddRatingSummary(newRating);
                    currentRatings.Add(
                        new BookSpecificRating
                        {
                            Rating = newRating.Rating,
                            RatingCategory = newRating.RatingCategory
                        }
                     );
                }
            }
        }
    }
}
