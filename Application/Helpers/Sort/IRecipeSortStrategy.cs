using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.Sort;

public interface IRecipeSortStrategy
{
    public IOrderedQueryable<Recipe> Sort(IQueryable<Recipe> recipes);
}
