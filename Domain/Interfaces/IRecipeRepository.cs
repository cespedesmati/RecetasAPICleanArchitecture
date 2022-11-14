using Domain.SeedWork;

namespace Domain.Interfaces;

public interface IRecipeRepository : IGenericRepository<Recipe>
{
    Task<IList<Recipe>> GetAllRecipes();
    Task<Recipe> GetAllUsers(Guid idRecipe);
    Task<Recipe> GetAllReviews(Guid idRecipe);
}
