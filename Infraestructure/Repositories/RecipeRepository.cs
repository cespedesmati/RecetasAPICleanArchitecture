using Domain.Interfaces;
using Domain;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
{
    private readonly DataContext dataContext;
    public RecipeRepository(DataContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext; 
    }


    public async Task<IList<Recipe>> GetAllRecipes()
    {
       /* var consulta = await dataContext.Recipes
            .Select(r => new Recipe
            {
                idRecipe = r.idRecipe,
                nameRecipe = r.nameRecipe,
                score = r.score,
                idUser = r.idUser,
                categories = r.categories.Select(c => new Category
                {
                    idCategory = c.idCategory,
                    name = c.name
                }).FirstOrDefault(),
                ingredients = r.ingredients.Select(i => new IngredientUsed
                {
                    idIngredientUsed = i.idIngredientUsed,
                    amount = i.amount,
                    unit = i.unit,
                    ingredient = i.ingredient,
                    comment = i.comment
                }).ToList()
            } ).ToList();*/

        return await dataContext.Recipes
            .Include(u => u.user)
            .Include(iu => iu.ingredients)!
                .ThenInclude(u => u.unit)
            .Include(iu => iu.ingredients)!
                .ThenInclude(iu => iu.ingredient)
            .Include(s => s.Steps)
            .Include(c => c.categories)
            .ToListAsync();
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
                .Select(c => new {
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
}
