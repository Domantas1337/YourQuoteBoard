namespace YourQuoteBoard.Interfaces.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task Insert(TEntity entity);
        public Task Delete(Guid id);
        public Task Save();
    }
}
