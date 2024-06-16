﻿using AutoMapper;
using YourQuoteBoard.DTO;
using YourQuoteBoard.DTO.Quote;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Quote, QuoteAddDTO>().ReverseMap();
            CreateMap<Quote, QuoteDisplayDTO>().ReverseMap();
        }
    }
}
