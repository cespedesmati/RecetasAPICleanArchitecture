using Domain;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly DataContext dataContext;
    public CategoryRepository(DataContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<Category> GetByName(string name)
    {
        var category = await dataContext.Categories
            .Where(x => x.name == name)
            .FirstOrDefaultAsync();

        return category;

    }
}
