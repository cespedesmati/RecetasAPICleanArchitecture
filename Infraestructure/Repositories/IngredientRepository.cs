using Domain;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
{

    private readonly DataContext dataContext;
    public IngredientRepository(DataContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<Ingredient> GetByName(string ingredientName)
    {
        var ingredient = await dataContext.Ingredients
            .Where(x => x.name == ingredientName)
            .FirstOrDefaultAsync();
        return ingredient;
    }

    public async Task<Ingredient> getIngredientByName(string name)
    {
        var ingredient = await dataContext.Ingredients
            .Where(x => x.name == name.ToLower().Trim())
            .FirstOrDefaultAsync();

        if (ingredient == null)
            throw new KeyNotFoundException();

        return ingredient;
    }
}
