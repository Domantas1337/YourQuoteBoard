using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Services
{
    public class FavoriteService(IFavoriteRepository _favoriteRepository) : IFavoriteService
    {
        public async Task<ICollection<Favorite>> GetFavoritesByUserId(string userId)
        {
            var favorites = await _favoriteRepository.GetByUserId(userId);
        
            return favorites;
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
        }
    }
}
