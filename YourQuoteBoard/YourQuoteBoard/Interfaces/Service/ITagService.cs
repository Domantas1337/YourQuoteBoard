using YourQuoteBoard.DTO.Tag;
using YourQuoteBoard.Enums;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface ITagService
    {    
        public Task<TagCreateDTO> AddTagAsync(TagCreateDTO tagCreateDTO);
        public Task<TagDisplayDTO[]> GetAllTagsAsync(TagType tagType);
    }

}

