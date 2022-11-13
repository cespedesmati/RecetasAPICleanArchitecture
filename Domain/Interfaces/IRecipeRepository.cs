using Domain.SeedWork;

namespace Domain.Interfaces;

public interface IRecipeRepository : IGenericRepository<Recipe>
{
    Task<IList<Recipe>> GetAllRecipes();
}
