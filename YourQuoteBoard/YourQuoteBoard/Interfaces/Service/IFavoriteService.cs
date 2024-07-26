using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Service
{
    public interface IFavoriteService
    {
        public Task Insert(string userId, Guid quoteId);
        public Task<ICollection<Favorite>> GetFavoritesByUserId(string userId);
    }
}
