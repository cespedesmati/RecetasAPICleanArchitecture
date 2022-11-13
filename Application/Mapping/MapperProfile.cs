﻿using Application.DTOs.Category;
using Application.DTOs.IngredientUsed;
using Application.DTOs.Recipe;
using Application.DTOs.Step;
using AutoMapper;
using Domain;

namespace Application.Mapping;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Recipe, RecipeRequestDto>().ReverseMap();
        CreateMap<Recipe, RecipeResponseDto>().ReverseMap();
        CreateMap<Category, CategoryRequestDto>().ReverseMap();
        CreateMap<IngredientUsed, IngredientUsedRequestDto>().ReverseMap();
        CreateMap<Step, StepRequestDto>().ReverseMap();

    }
}