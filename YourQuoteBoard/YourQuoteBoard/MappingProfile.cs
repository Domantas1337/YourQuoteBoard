﻿using AutoMapper;
using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Book;
using YourQuoteBoard.DTO.Folder;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.DTO.Rating.Book;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.DTO.Tag;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Entity.Books;
using YourQuoteBoard.Entity.Quotes;
using YourQuoteBoard.Utilities;

namespace YourQuoteBoard
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {

            CreateMap<TagDisplayDTO, Tag>();

            CreateMap<BookAddDTO, Book>().ReverseMap();

            CreateMap<BookDisplayDTO, Book>();
            CreateMap<Book, BookDisplayDTO>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));

            CreateMap<Tag, TagDisplayDTO>();

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
            CreateMap<QuoteSpecificRating, QuoteSpecificRatingDTO>().ReverseMap();
            CreateMap<BookSpecificRating, BookSpecificRatingDTO>().ReverseMap();

        }
    }
}
