using AutoMapper;
using YourQuoteBoard.DTO.Rating.Quote;
using YourQuoteBoard.DTO.Tag;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagCreateDTO>().ReverseMap();
            CreateMap<Tag, TagDisplayDTO>().ReverseMap();
        }
    }
}
