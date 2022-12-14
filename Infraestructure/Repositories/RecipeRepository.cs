using Domain.Interfaces;
using Domain;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Helpers.Sort;

namespace Infraestructure.Repositories;

public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
{
    private readonly DataContext dataContext;
    private readonly IRecipeSortFactory recipeSortFactory; 
    public RecipeRepository(DataContext dataContext, IRecipeSortFactory recipeSortFactory) : base(dataContext)
    {
        this.dataContext = dataContext;
        this.recipeSortFactory = recipeSortFactory;
    }

    public async Task<IList<Recipe>> GetAllRecipes(string? sortField, string? sortDirection)
    {
        var recipes = dataContext.Recipes.AsQueryable();

        recipes = recipes
            .Include(u => u.user)
            .Include(iu => iu.ingredients)!
                .ThenInclude(u => u.unit)
            .Include(iu => iu.ingredients)!
                .ThenInclude(iu => iu.ingredient)
            .Include(s => s.Steps)
            .Include(c => c.categories);

        var sortStrategy = recipeSortFactory.CreateSortStrategy(sortField, sortDirection);
        if (sortStrategy != null)
        {
            recipes = sortStrategy.Sort(recipes);
        }

        return await recipes.ToListAsync();
    }

    public async Task<object> GetAll2()
    {
        var consulta = await dataContext.Recipes
            .Select(r => new
            {
                r.idRecipe,
                r.nameRecipe,
                r.score,
                r.idUser,
                categories = r.categories!
                .Select(c => new
                {
                    c.idCategory,
                    c.name
                }).ToList(),
                ingredients = r.ingredients!
                .Select(i => new
                {
                    i.idIngredientUsed,
                    i.amount,
                    unit = new
                    {
                        i.unit.idUnit,
                        i.unit.description,
                    },
                    ingredient = new
                    {
                        i.ingredient.idIngredient,
                        i.ingredient.name,
                    },

                    i.comment
                }).ToList(),
                steps = r.Steps!.Select(s => new
                {
                    s.idStep,
                    s.nstep,
                    s.description
                })
            }).ToListAsync();

        return consulta;

    }

    public async Task<Recipe> GetAllUsers(Guid idRecipe)
    {
        var entity = await dataContext.Recipes
            .Where(x => x.idRecipe == idRecipe)
                .Include(x => x.bookmarks)!
                    .ThenInclude(y1 => y1.user)
            .FirstOrDefaultAsync();

        if (entity == null)
            throw new KeyNotFoundException();

        return entity;
    }

    public async Task<Recipe> GetAllReviews(Guid idRecipe)
    {
        var entity = await dataContext.Recipes
            .Where(x => x.idRecipe == idRecipe)
                .Include(x => x.reviews)
            .FirstOrDefaultAsync();

        if (entity == null)
            throw new KeyNotFoundException();

        return entity;
    }

    public async Task<IList<Recipe>> GetAllRecipes()
    {
        return await dataContext.Recipes
            .Include(u => u.user)
            .Include(iu => iu.ingredients)!
                .ThenInclude(u => u.unit)
            .Include(iu => iu.ingredients)!
                .ThenInclude(iu => iu.ingredient)
            .Include(s => s.Steps)
            .Include(c => c.categories).ToListAsync();
    }
}

