using Application.DTOs.Review;
using Application.Helpers;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IRecipeService recipeService;

        public ReviewController(IUserService userService, IRecipeService recipeService)
        {
            this.userService = userService;
            this.recipeService = recipeService;
        }


        [HttpGet("Recipe")]
        public async Task<ActionResult<BaseResponse<IEnumerable<ReviewResponseDto>>>> GetReviewByRecipe(Guid idRecipe)
        {
            var response = await recipeService.GetReviewsByRecipe(idRecipe);
            return Ok(response);
        }

        [HttpGet("User")]
        public async Task<ActionResult<BaseResponse<IEnumerable<ReviewResponseDto>>>> GetReviewByUser(Guid idUser)
        {
            var response = await userService.GetReviewsByUser(idUser);
            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<BaseResponse<Guid>>> AddReview(ReviewRequestDto reviewDto, Guid idUser, Guid idRecipe)
        {
            var response = await userService.AddReview(reviewDto,idUser,idRecipe);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteReview(Guid idReview)
        {
            var response = await userService.DeleteReview(idReview);
            return Ok(response);
        }
    }
}
