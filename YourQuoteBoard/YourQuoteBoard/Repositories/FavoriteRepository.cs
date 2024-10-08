﻿using Microsoft.EntityFrameworkCore;
using YourQuoteBoard.Data;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class FavoriteRepository(ApplicationDbContext applicationDbContext) : GenericRepository<Favorite>(applicationDbContext), IFavoriteRepository
    {

        public async Task<Favorite?> CheckIfFavoriteExistsAsync(Guid quoteId, string userId)
        {
            var favorite = await dbSet.Where(f => f.ApplicationUserId.Equals(userId))
                                      .FirstOrDefaultAsync(f => quoteId.Equals(f.QuoteId));

            return favorite;                                                   
        }

        public async Task<ICollection<Favorite>> GetByUserId(string userId)
        {
            var favorites = await dbSet.Where(f => f.ApplicationUserId.Equals(userId)).ToListAsync();

            return favorites;
        }

    }
}
