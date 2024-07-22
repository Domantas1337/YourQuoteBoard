using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class TagRepository(ApplicationDbContext _context) : ITagRepository
    {
        public async Task<Tag> AddTagAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            return tag;
        }

        public async Task<Tag[]> GetAllBookTagsAsync()
        {
            var tags = await _context.Tags
                                     .Where(t => t.Discriminator == Enums.TagType.Book)
                                     .ToArrayAsync();

            return tags;
        }

        public async Task<Tag[]> GetAllQuoteTagsAsync()
        {
            var tags = await _context.Tags
                                     .Where(t => t.Discriminator == Enums.TagType.Quote)
                                     .ToArrayAsync();

            return tags;
        }

        public async Task<Tag[]> GetAllTagsAsync(Tag tag)
        {
            var tags = await _context.Tags.ToArrayAsync();

            return tags;
        }

    }
}
