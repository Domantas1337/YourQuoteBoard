﻿using AutoMapper;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.Entity.Quotes;

namespace YourQuoteBoard.Profiles
{
    public class QuoteRatingProfile : Profile
    {
        public QuoteRatingProfile() 
        {
            CreateMap<QuoteRatingForDirectUserInteractionDTO, QuoteRating>().AfterMap((src, dest, context) =>
            {
                dest.ApplicationUserId = (string)context.Items["userId"];
            });
            CreateMap<QuoteRating, QuoteRatingForDirectUserInteractionDTO>();

            CreateMap<QuoteRatingCreateDTO, QuoteRating>().AfterMap((src, dest, context) =>
            {
                dest.ApplicationUserId = (string)context.Items["userId"];
            });
            CreateMap<QuoteRating, QuoteRatingCreateDTO>();

            CreateMap<QuoteRating, QuoteRatingDisplayDTO>().ReverseMap();
            CreateMap<QuoteRatingUpdateDTO, QuoteRating>().ReverseMap();
        }
    }
}
