using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using YourQuoteBoard.Data;
using YourQuoteBoard.Interfaces.Repository;

namespace YourQuoteBoard.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal DbSet<TEntity> dbSet;
        internal ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            this.context = applicationDbContext;
            this.dbSet = context.Set<TEntity>();
        }


        public virtual async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task Delete(TEntity entityToDelete)
        {

            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);
        }

        public virtual async Task Save()
        {
            await context.SaveChangesAsync();
        }

    }
}
