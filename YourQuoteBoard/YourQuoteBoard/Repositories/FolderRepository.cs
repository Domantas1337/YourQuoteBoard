using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class FolderRepository(ApplicationDbContext _applicationDbContext) : IFolderRepository
    {
        public async Task<Folder> AddQuoteFolderAsync(Folder folder)
        {
            await _applicationDbContext.Folders.AddAsync(folder);
            await _applicationDbContext.SaveChangesAsync();

            return folder;
        }

        public async Task<Folder> GetQuoteFolderByIdAsync(Guid folderId)
        {
            var folder = await _applicationDbContext.Folders
                                .Include(x => x.Quotes)
                                .FirstOrDefaultAsync(f => f.FolderId.Equals(folderId));
            
            if (folder == null)
            {
                throw new KeyNotFoundException(nameof(folder));
            }
            
            return folder;
        }

        public async Task<List<Folder>> GetQuoteFoldersForDisplayAsync(string userId)
        {
            var folders = await _applicationDbContext.Folders
                                .Where(f => f.ApplicationUserId.Equals(userId))
                                .ToListAsync();
            return folders;
        }

        public async Task Save()
        {
            await _applicationDbContext.SaveChangesAsync();
        }

    }
}
