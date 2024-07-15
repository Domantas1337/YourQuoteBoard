using YourQuoteBoard.DTO.Folder;
using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IFolderService
    {
        public Task<FolderContentDTO> GetQuoteFolderContentAsync(Guid folderId);
        public Task<FolderCreateDTO> AddQuoteFolderAsync(FolderCreateDTO folder, string userId);
        public Task<List<FolderDisplayDTO>> GetQuoteFoldersForDisplayAsync(string userId);
    }
}
