using Domain.SeedWork;

namespace Domain.Interfaces;


public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<Category> GetByName(string name);
}
