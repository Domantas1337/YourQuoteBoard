using AutoMapper;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.Entity.Books;

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

            CreateMap<BookRating, BookRatingDTO>().ReverseMap()
                .ForMember(dest => dest.BookRatingId, opt => opt.Ignore()) 
                .ForMember(dest => dest.BookId, opt => opt.Ignore()) 
                .ForMember(dest => dest.Book, opt => opt.Ignore()) 
                .ForMember(dest => dest.ApplicationUserId, opt => opt.Ignore()); 

            CreateMap<BookRating, BookRatingDisplayDTO>()
                .ForMember(dest => dest.SpecificRatings, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId));
            
            CreateMap<BookRatingDisplayDTO, BookRating>()
                .ForMember(dest => dest.BookRatingId, opt => opt.Ignore()) 
                .ForMember(dest => dest.OverallRating, opt => opt.MapFrom(src => src.OverallRating))
                .ForMember(dest => dest.SpecificRatings, opt => opt.MapFrom(src => src.SpecificRatings))
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
                .ForMember(dest => dest.ApplicationUserId, opt => opt.Ignore()) 
                .ForMember(dest => dest.Book, opt => opt.Ignore());

            CreateMap<BookRatingUpdateDTO, BookRating>().AfterMap((src, dest, context) =>
            {
                dest.OverallRating = (double)context.Items["newRating"];
            });
        }
    }
}
