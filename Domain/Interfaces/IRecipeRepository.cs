using Domain.SeedWork;

namespace Domain.Interfaces;

public interface IRecipeRepository : IGenericRepository<Recipe>
{
    Task<IList<Recipe>> GetAllRecipes(string? sortField, string? sortDirection, int page, int pageSize);
    Task<Recipe> GetAllUsers(Guid idRecipe);
    Task<Recipe> GetAllReviews(Guid idRecipe);

    Task<int> CountRecipes();

}
