using AutoMapper;
using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Book;
using YourQuoteBoard.DTO.Folder;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.DTO.Tag;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Utilities;

namespace YourQuoteBoard
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {

            CreateMap<TagDisplayDTO, Tag>();

            CreateMap<Book, BookDisplayDTO>().ReverseMap();
            CreateMap<BookAddDTO, Book>().ReverseMap();

            CreateMap<QuoteAddDTO, Quote>()
                .AfterMap((src, dest, context) =>
                    {
                        dest.ApplicationUserId = (string)context.Items["userId"];
                    }
                );
            CreateMap<Quote, QuoteAddDTO>();
            CreateMap<Quote, QuoteDisplayDTO>().ReverseMap();

            

            CreateMap<FolderCreateDTO, Folder>()
                    .AfterMap((src, dest, context) =>
                    {
                        dest.ApplicationUserId = (string)context.Items["userId"];
                    });
            CreateMap<Folder, FolderCreateDTO>();
            CreateMap<Folder, FolderContentDTO>().ReverseMap();
            CreateMap<Folder, FolderDisplayDTO>().ReverseMap();
            CreateMap<Folder, FolderUpdateDTO>().ReverseMap();
        }
    }
}
