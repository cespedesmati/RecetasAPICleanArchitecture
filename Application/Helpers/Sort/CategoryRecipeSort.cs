﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.Sort;

public class CategoryRecipeSort : IRecipeSortStrategy
{
    private readonly string sortDirection;

    public CategoryRecipeSort(string sortDirection)
    {
        this.sortDirection = sortDirection;
    }

    public IOrderedQueryable<Recipe> Sort(IQueryable<Recipe> recipes)
    {
        return sortDirection == "asc" ? recipes.OrderBy(r => r.categories) : recipes.OrderByDescending(r => r.categories);
    }
}
