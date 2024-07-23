using YourQuoteBoard.DTO.Tag;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface ITagRepository
    {
        public Task<Tag> AddTagAsync(Tag tag);
        public Task<Tag[]> GetAllTagsAsync(Tag tag);
        public Task<Tag[]> GetAllBookTagsAsync();
        public Task<Tag[]> GetAllQuoteTagsAsync();
        public Task<Tag[]> GetAllDefaultQuoteTagsAsync();
        public Task<Tag[]> GetAllDefaultBookTagsAsync();
        public Task<ICollection<Tag>> GetTagsByTagIdAsync(ICollection<Guid> ids);
    }
}
