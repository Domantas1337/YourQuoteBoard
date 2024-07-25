using AutoMapper;
using YourQuoteBoard.DTO.Folder;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Exceptions;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Services
{
    public class FolderService(IFolderRepository _folderRepository, IQuoteRepository _quoteRepository, IMapper _mapper) : IFolderService
    {
        public async Task<FolderCreateDTO> AddQuoteFolderAsync(FolderCreateDTO folder, string userId)
        {
            var folderToAdd = _mapper.Map<Folder>(folder, opts =>
            {
                opts.Items["userId"] = userId;
            });
            var addedFolder = await _folderRepository.AddQuoteFolderAsync(folderToAdd);

            return folder;
        }

        public async Task<FolderContentDTO> GetQuoteFolderContentAsync(Guid folderId)
        {
            var folder = await _folderRepository.GetQuoteFolderByIdAsync(folderId);
            var folderContent = _mapper.Map<FolderContentDTO>(folder);

            return folderContent;
        }

        public async Task<List<FolderDisplayDTO>> GetQuoteFoldersForDisplayAsync(string userId)
        {
            var folders = await _folderRepository.GetQuoteFoldersForDisplayAsync(userId);
            var foldersForDislplay = _mapper.Map<List<FolderDisplayDTO>>(folders);
            
            return foldersForDislplay;
        }

        public async Task AddQuoteToFolderAsync(Guid folderId, Guid quoteId)
        {
            var folder = await _folderRepository.GetQuoteFolderByIdAsync(folderId);
            var quote = await _quoteRepository.GetQuoteByIdAsync(quoteId);

            if (folder == null)
            {
                throw new EntityNotFoundException("Folder not found.");
            }

            if (quote == null)
            {
                throw new EntityNotFoundException("Quote not found.");
            }

            folder.AddQuote(quote);

            await _folderRepository.Save();
        }
    }
}
