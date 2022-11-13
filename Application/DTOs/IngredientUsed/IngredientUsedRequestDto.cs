namespace Application.DTOs.IngredientUsed
{
    public class IngredientUsedRequestDto
    {
        public string amount { get; set; }
        public string unitDescription { get; set; }
        public string ingredientName { get; set; }
        public string comment { get; set; } = string.Empty;
    }
}