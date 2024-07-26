using YourQuoteBoard.Entity;

namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IFavoriteRepository : IGenericRepository<Favorite>
    {
        public Task<ICollection<Favorite>> GetByUserId(string userId);

    }
}
