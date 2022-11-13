using Domain.SeedWork;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly DataContext dataContext;

    public GenericRepository(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public Task Delete(TEntity entity)
    {
        dataContext.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return  await dataContext.Set<TEntity>().ToListAsync();
    }

    public IQueryable<TEntity> GetAllQuery()
    {
        return (from c in dataContext.Set<TEntity>()
                select c).AsNoTracking().AsQueryable();
    }

    public async Task<TEntity> GetById(Guid id)
    {
        var entity = await dataContext.Set<TEntity>().FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException();

        return entity;
    }

    public Task Insert(TEntity entity)
    {
        dataContext.Set<TEntity>().Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(TEntity entity)
    {
        dataContext.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }
}
