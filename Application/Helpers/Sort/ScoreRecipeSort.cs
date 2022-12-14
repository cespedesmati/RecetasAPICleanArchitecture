using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.Sort
{
    public class ScoreRecipeSort : IRecipeSortStrategy
    {
        private readonly string sortDirection;

        public ScoreRecipeSort(string sortDirection)
        {
            this.sortDirection = sortDirection;
        }

        public IOrderedQueryable<Recipe> Sort(IQueryable<Recipe> recipes)
        {
            return sortDirection == "asc" ? recipes.OrderBy(r => r.score) : recipes.OrderByDescending(r => r.score);
        }
    }
}
