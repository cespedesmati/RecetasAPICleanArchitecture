using Application.DTOs.Recipe;
using Application.Helpers;

namespace Application.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<BaseResponse<IList<RecipeResponseDto>>> GetAll();
        Task<BaseResponse<Guid>> Create(RecipeRequestDto requestDTO);
        Task<BaseResponse<bool>> Delete(Guid id);
        Task Update(RecipeUpdateRequestDto recipeDTO, Guid id);

        
    }
}