using AutoMapper;
using YourQuoteBoard.DTO;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Exceptions;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Services
{
    public class FavoriteService(IFavoriteRepository _favoriteRepository, IQuoteRepository _quoteRepository, IMapper _mapper) : IFavoriteService
    {
        public async Task<bool> CheckIfQuoteIsFavoriteAsync(Guid quoteId, string userId)
        {
            var favorite = await _favoriteRepository.CheckIfFavoriteExistsAsync(quoteId, userId);
            
            if (favorite is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ICollection<QuoteDisplayDTO>> GetFavoritesByUserId(string userId)
        {
            var favorites = await _favoriteRepository.GetByUserId(userId);
            var quoteIds = favorites.Select(f => f.QuoteId).ToList();
            var quotes = await _quoteRepository.GetQuotesByIds(quoteIds);

            return _mapper.Map<List<QuoteDisplayDTO>>(quotes);
        }

        public async Task Insert(string userId, Guid quoteId)
        {
            Favorite favorite = new()
            {
                ApplicationUserId = userId,
                QuoteId = quoteId,
                TimeAdded = DateTime.Now,
            };

            await _favoriteRepository.Insert(favorite);
            await _favoriteRepository.Save();
        }

        public async Task RemoveFavorite(Guid quoteId, string userId)
        {
            Favorite? favoriteToRemove = await _favoriteRepository.CheckIfFavoriteExistsAsync(quoteId, userId);
        
            if (favoriteToRemove is not null) 
            {
                await _favoriteRepository.Delete(favoriteToRemove);
            }
            else
            {
                throw new EntityNotFoundException("Enity not found, nothing to remove.");
            }
        }
    }
}
