namespace Domain.SeedWork
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        IQueryable<TEntity> GetAllQuery();
        Task<TEntity> GetById(Guid id);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
