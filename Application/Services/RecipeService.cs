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

namespace Application.Services
{
    public class RecipeService : IRecipeService
    {
        public Task<BaseResponse<Guid>> Create(RecipeRequestDto requestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IList<RecipeResponseDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(RecipeUpdateRequestDto recipeDTO, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
