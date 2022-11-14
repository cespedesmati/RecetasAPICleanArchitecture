using Application.DTOs.Category;
using Application.DTOs.IngredientUsed;
using Application.DTOs.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Recipe;

public class RecipeResponseDto
{
    public Guid IdRecipe { get; set; }
    public string nameRecipe { get; set; }
    public int score { get; set; }
    public Guid? idUser { get; set; }
    public IList<IngredientUsedRequestDto>? ingredients { get; set; }
    public IList<StepRequestDto>? Steps { get; set; }
    public IList<CategoryRequestDto>? categories { get; set; }
}
