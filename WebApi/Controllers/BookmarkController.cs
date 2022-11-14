using Application.DTOs.Recipe;
using Application.DTOs.User;
using Application.Helpers;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IRecipeService recipeService;

        public BookmarkController(IUserService userService, IRecipeService recipeService)
        {
            this.userService = userService;
            this.recipeService = recipeService;
        }


        [HttpGet("Recipe")]
        public async Task<ActionResult<BaseResponse<IEnumerable<UserResponseDto>>>> GetBookmarksByRecipe(Guid idRecipe)
        {
            var response = await recipeService.GetBookmarksByRecipe(idRecipe);
            return Ok(response);
        }

        [HttpGet("User")]
        public async Task<ActionResult<BaseResponse<IEnumerable<RecipeResponseDto>>>> GetBookmarksByUser(Guid idUser)
        {
            var response = await userService.GetBookmarksByUser(idUser);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Guid>>> AddBookmark(Guid idUser, Guid idRecipe)
        {
            var response = await userService.AddBookmark(idUser, idRecipe);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBookmark(Guid idUser, Guid idRecipe)
        {
            var response = await userService.DeleteBookmark(idUser,idRecipe);
            return Ok(response);
        }
    }
}
