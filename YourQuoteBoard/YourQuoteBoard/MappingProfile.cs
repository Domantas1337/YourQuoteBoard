﻿using AutoMapper;
using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Book;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Utilities;

namespace YourQuoteBoard
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Book, BookDisplayDTO>().ReverseMap();
            CreateMap<Book, BookAddDTO>().ReverseMap();

            CreateMap<QuoteAddDTO, Quote>()
                .AfterMap((src, dest, context) =>
                    {
                        dest.ApplicationUserId = (string)context.Items["userId"];
                    }
                );
            CreateMap<Quote, QuoteAddDTO>();
            CreateMap<Quote, QuoteDisplayDTO>().ReverseMap();

            CreateMap<BookRatingDTO, BookRating>().AfterMap((src, dest, context) =>
            {
                dest.ApplicationUserId = (string)context.Items["userId"];
            });
            CreateMap<BookRating, BookRatingDTO>();

            CreateMap<BookRating, BookRatingUpdateDTO>().ReverseMap();

        }
    }
}
