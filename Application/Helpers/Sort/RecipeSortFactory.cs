using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.Sort;

public class RecipeSortFactory : IRecipeSortFactory
{
    public IRecipeSortStrategy CreateSortStrategy(string sortField, string sortDirection)
    {
        switch (sortField)
        {
            case "name":
                return new NameRecipeSort(sortDirection);
            case "score":
                return new ScoreRecipeSort(sortDirection);
            case "category":
                return new CategoryRecipeSort(sortDirection);
            default:
                return null;
        }
    }
}
