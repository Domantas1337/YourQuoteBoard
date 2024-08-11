using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IFolderRepository
    {
        public Task<Folder> GetQuoteFolderByIdAsync(Guid folderId);
        public Task<Folder> AddQuoteFolderAsync(Folder folder);
        public Task<List<Folder>> GetQuoteFoldersForDisplayAsync(string userId);
        public Task DeleteQuoteFolderAsync(Folder folder);
        public Task Save();
    }
}
