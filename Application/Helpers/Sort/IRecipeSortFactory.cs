using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.Sort
{
    public interface IRecipeSortFactory
    {
        public IRecipeSortStrategy CreateSortStrategy(string? sortField, string? sortDirection);
    }
}
