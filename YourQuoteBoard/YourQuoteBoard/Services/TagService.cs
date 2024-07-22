using AutoMapper;
using YourQuoteBoard.DTO.Tag;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Enums;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Services
{
    public class TagService(ITagRepository _tagRepository, IMapper _mapper) : ITagService
    {
        public async Task<TagCreateDTO> AddTagAsync(TagCreateDTO tagCreateDTO)
        {
            var tag = _mapper.Map<Tag>(tagCreateDTO);
            var addedTag = await _tagRepository.AddTagAsync(tag);

            return tagCreateDTO;
        }

        public async Task<TagDisplayDTO[]> GetAllTagsAsync(TagType tagType)
        {
            var tags = await GetTagsByTypeAsync(tagType);
            return _mapper.Map<TagDisplayDTO[]>(tags);
        }

        private async Task<Tag[]> GetTagsByTypeAsync(TagType tagType)
        {
            return tagType switch
            {
                TagType.Book => await _tagRepository.GetAllBookTagsAsync(),
                TagType.Quote => await _tagRepository.GetAllQuoteTagsAsync(),
                _ => throw new ArgumentException($"Unsupported tag type: {tagType}", nameof(tagType))
            };
        }


    }
}
