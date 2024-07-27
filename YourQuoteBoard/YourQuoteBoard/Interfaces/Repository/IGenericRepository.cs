namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task Insert(TEntity entity);
        public Task Delete(TEntity entityToDelete);
        public Task Save();
    }
}
