using Application.DTOs.Category;
using Application.DTOs.IngredientUsed;
using Application.DTOs.Recipe;
using Application.DTOs.Review;
using Application.DTOs.Step;
using Application.DTOs.User;
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
        CreateMap<User, UserRequestDto>().ReverseMap();
        CreateMap<User, UserResponseDto>().ReverseMap();
        CreateMap<Review, ReviewRequestDto>().ReverseMap();
        CreateMap<Review, ReviewResponseDto>().ReverseMap();

    }
}
