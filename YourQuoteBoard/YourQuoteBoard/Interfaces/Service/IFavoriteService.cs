using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IFavoriteService
    {
        public Task<bool> CheckIfQuoteIsFavoriteAsync(Guid quoteId, string userId);
        public Task Insert(string userId, Guid quoteId);
        public Task<ICollection<Favorite>> GetFavoritesByUserId(string userId);
        public Task RemoveFavorite(Guid quoteId, string userId);
    }
}
