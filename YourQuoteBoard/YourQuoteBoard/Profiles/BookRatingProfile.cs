using AutoMapper;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Profiles
{
    public class BookRatingProfile : Profile
    {
        public BookRatingProfile() {
            CreateMap<BookRatingForDirectUserInteractionDTO, BookRating>().AfterMap((src, dest, context) =>
            {
                dest.ApplicationUserId = (string)context.Items["userId"];
            });
            CreateMap<BookRating, BookRatingForDirectUserInteractionDTO>();

            CreateMap<BookRatingCreateDTO, BookRating>().AfterMap((src, dest, context) =>
            {
                dest.ApplicationUserId = (string)context.Items["userId"];
            });
            CreateMap<BookRating, BookRatingCreateDTO>();

            CreateMap<BookRating, BookRatingDisplayDTO>().ReverseMap();
            CreateMap<BookRatingForUpdateDTO, BookRating>().AfterMap((src, dest, context) =>
            {
                dest.OverallRating = (double)context.Items["newRating"];
            });
        }
    }
}
