using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IFolderRepository
    {
        public Task<Folder> GetQuoteFolderContentAsync(Guid folderId);
        public Task<Folder> AddQuoteFolderAsync(Folder folder);
        public Task<List<Folder>> GetQuoteFoldersForDisplayAsync(string userId);
    }
}
