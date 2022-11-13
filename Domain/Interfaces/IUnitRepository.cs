using Domain.SeedWork;

namespace Domain.Interfaces;

public interface IUnitRepository : IGenericRepository<Unit>
{
    Task<Unit> GetByName(string unitDescription);
}
