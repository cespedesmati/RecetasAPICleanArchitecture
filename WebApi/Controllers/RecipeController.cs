using Application.DTOs.Recipe;
using Application.Helpers;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipeController : Controller
{
    private readonly IRecipeService recipeService;

    public RecipeController(IMapper mapper, IRecipeService recipeService)
    {
        this.recipeService = recipeService;
    }

    [HttpGet]
    public async Task<ActionResult<BasePaginatedResponse<IList<RecipeResponseDto>>>> Get([FromQuery] string? sortField, [FromQuery] string? sortDirection, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var response = await recipeService.GetAll(sortField,sortDirection,page,pageSize);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetById(Guid id)
    {
        var response = await recipeService.GetById(id);
        return Ok(response);
    }

    [HttpPost("crearReceta")]
    public async Task<ActionResult<BaseResponse<Guid>>> CreateRecipe([FromBody] RecipeRequestDto recipeDTO)
    {
        var response = await recipeService.Create(recipeDTO);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Recipe>> Put([FromBody] RecipeUpdateRequestDto recipeDTO, Guid id)
    {
        if (!ModelState.IsValid) { return BadRequest("Datos invalidos"); }
        await recipeService.Update(recipeDTO, id);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var response = await recipeService.Delete(id);
        return Ok(response);
    }
}
