using Domain.SeedWork;

namespace Domain.Interfaces;

public interface IIngredientRepository : IGenericRepository<Ingredient>
{
    Task<Ingredient> GetByName(string ingredientName);
}
