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
    }
}
