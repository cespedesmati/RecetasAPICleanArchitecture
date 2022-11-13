using Application.DTOs.Category;
using Application.DTOs.IngredientUsed;
using Application.DTOs.Recipe;
using Application.DTOs.Step;
using Application.Helpers;
using Domain.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class RecipeService : IRecipeService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public RecipeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


    public async Task<BaseResponse<IList<RecipeResponseDto>>> GetAll()
    {
        var response = new BaseResponse<IList<RecipeResponseDto>>();
        var recipes = await unitOfWork.RecipeRepository.GetAllRecipes();
        if (recipes is not null)
        {
            response.IsSuccess = true;
            response.Data = mapper.Map<IList<RecipeResponseDto>>(recipes);
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }
        else
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_FAILED;
        }
        return response;
    }

    public async Task<BaseResponse<RecipeResponseDto>> GetById(Guid id)
    {
        var response = new BaseResponse<RecipeResponseDto>();
        var recipe = await unitOfWork.RecipeRepository.GetById(id);
        if (recipe is not null)
        {
            response.IsSuccess = true;
            response.Data = mapper.Map<RecipeResponseDto>(recipe);
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }
        else
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_FAILED;
        }
        return response;
    }


    public async Task<BaseResponse<Guid>> Create(RecipeRequestDto recipeDTO)
    {
        User userCliente = await unitOfWork.UserRepository.GetById(recipeDTO.idUser);

        Recipe recipe = new() { nameRecipe = recipeDTO.nameRecipe, user = userCliente };

        await AddCategories(recipeDTO.categories, recipe);
        await AddIngredients(recipeDTO.ingredients, recipe);
        AddSteps(recipeDTO.Steps, recipe);

        await unitOfWork.RecipeRepository.Insert(recipe);

        int result = await unitOfWork.SaveChangesAsync();
        var response = new BaseResponse<Guid>();
        if (result > 0)
        {
            response.IsSuccess = true;
            response.Data = recipe.idRecipe;
            response.Message = ReplyMessage.MESSAGE_SAVE;
        }
        else
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_FAILED;
        }
        return response;
    }

    public async Task Update(RecipeUpdateRequestDto recipeDTO, Guid id)
    {
        Recipe recipe = await unitOfWork.RecipeRepository.GetById(id);

        recipe.nameRecipe = recipeDTO.nameRecipe ?? recipe.nameRecipe;
        if (recipeDTO.categories is not null)
        {
            recipe.categories!.Clear();
            await AddCategories(recipeDTO.categories, recipe);

        }
        if (recipeDTO.ingredients is not null)
        {
            recipe.ingredients!.Clear();
            await AddIngredients(recipeDTO.ingredients, recipe);
        }
        if (recipeDTO.Steps is not null)
        {
            recipe.Steps!.Clear();
            AddSteps(recipeDTO.Steps, recipe);
        }
        await unitOfWork.SaveChangesAsync();
    }

    public async Task<BaseResponse<bool>> Delete(Guid id)
    {
        var recipe = await unitOfWork.RecipeRepository.GetById(id);
        await unitOfWork.RecipeRepository.Delete(recipe);
        int result = await unitOfWork.SaveChangesAsync();
        var response = new BaseResponse<bool>();
        if (result > 0)
        {
            response.IsSuccess = true;
            response.Data = true;
            response.Message = ReplyMessage.MESSAGE_DELETE;
        }
        else
        {
            response.IsSuccess = false;
            response.Message = ReplyMessage.MESSAGE_FAILED;
        }
        return response;
    }

    private static void AddSteps(IList<StepRequestDto> stepsDTO, Recipe recipe)
    {
        foreach (StepRequestDto stepDto in stepsDTO)
        {
            Step newStep = new()
            {
                nstep = stepDto.nstep,
                title = stepDto.title,
                description = stepDto.description,
                recipe = recipe
            };
            recipe.Steps!.Add(newStep);
        }
    }

    private async Task AddIngredients(IList<IngredientUsedRequestDto> ingredientsDTO, Recipe recipe)
    {
        foreach (IngredientUsedRequestDto ingredientUsedDto in ingredientsDTO)
        {
            Ingredient ingredientAux = await unitOfWork.IngredientRepository.GetByName(ingredientUsedDto.ingredientName);

            if (ingredientAux is null)
            {
                ingredientAux = new Ingredient() { name = ingredientUsedDto.ingredientName };
                await unitOfWork.IngredientRepository.Insert(ingredientAux);
            }

            Unit unitAux = await unitOfWork.UnitRepository.GetByName(ingredientUsedDto.unitDescription);

            if (unitAux is null)
            {
                unitAux = new Unit() { description = ingredientUsedDto.unitDescription };
                await unitOfWork.UnitRepository.Insert(unitAux);
            }

            IngredientUsed ingredientUsed = new()
            {
                amount = ingredientUsedDto.amount,
                unit = unitAux,
                ingredient = ingredientAux,
                comment = ingredientUsedDto.comment,
                recipe = recipe
            };
            recipe.ingredients!.Add(ingredientUsed);
        }
    }

    private async Task AddCategories(IList<CategoryRequestDto> categoriesDTO, Recipe recipe)
    {
        foreach (CategoryRequestDto itemDto in categoriesDTO)
        {
            Category categoryAux = await unitOfWork.CategoryRepository.GetByName(itemDto.name);
            if (categoryAux is null)
            {
                categoryAux = new() { name = itemDto.name };
                await unitOfWork.CategoryRepository.Insert(categoryAux);
            }
            recipe.categories!.Add(categoryAux);
        }
    }


}