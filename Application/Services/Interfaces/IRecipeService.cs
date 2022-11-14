using Application.DTOs.Recipe;
using Application.DTOs.Review;
using Application.DTOs.User;
using Application.Helpers;

namespace Application.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<BaseResponse<IList<RecipeResponseDto>>> GetAll();
        Task<BaseResponse<RecipeResponseDto>> GetById(Guid id);
        Task<BaseResponse<Guid>> Create(RecipeRequestDto requestDTO);
        Task<BaseResponse<bool>> Delete(Guid id);
        Task Update(RecipeUpdateRequestDto recipeDTO, Guid id);
        Task<BaseResponse<IEnumerable<UserResponseDto>>> GetBookmarksByRecipe(Guid idRecipe);
        Task <BaseResponse<IEnumerable<ReviewResponseDto>>> GetReviewsByRecipe(Guid idRecipe);
    }
}