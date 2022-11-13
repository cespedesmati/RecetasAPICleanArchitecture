using Domain.Interfaces;
using Domain;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class UnitRepository : GenericRepository<Unit>, IUnitRepository
{
    private readonly DataContext dataContext;
    public UnitRepository(DataContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<Unit> GetByName(string unitDescription)
    {
        var unit = await dataContext.Unit
            .Where(x => x.description == unitDescription)
            .FirstOrDefaultAsync();

        return unit;
    }
}
