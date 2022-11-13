using Domain.Interfaces;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext dataContext;
    public IBookMarkRepository BookMarkRepository { get; private set; }
    public ICategoryRepository CategoryRepository { get; private set; }
    public IIngredientRepository IngredientRepository { get; private set; }
    public IIngredientUsedRepository IngredientUsedRepository { get; private set; }
    public IRecipeRepository RecipeRepository { get; private set; }
    public IReviewRepository ReviewRepository { get; private set; } 
    public IStepRepository StepRepository { get; private set; }
    public IUnitRepository UnitRepository { get; private set; }
    public IUserRepository UserRepository { get; private set; }

    public UnitOfWork(DataContext dataContext, IBookMarkRepository bookMarkRepository, ICategoryRepository categoryRepository, IIngredientRepository ingredientRepository, IIngredientUsedRepository IngredientUsedRepository, IRecipeRepository  recipeRepository, IReviewRepository reviewRepository, IStepRepository stepRepository, IUnitRepository unitRepository, IUserRepository userRepository)
    {
        this.dataContext = dataContext;
        this.BookMarkRepository = bookMarkRepository;
        this.CategoryRepository = categoryRepository;
        this.IngredientRepository = ingredientRepository;
        this.IngredientUsedRepository = IngredientUsedRepository;
        this.RecipeRepository = recipeRepository;
        this.ReviewRepository = reviewRepository;
        this.StepRepository = stepRepository;
        this.UnitRepository = unitRepository;
        this.UserRepository = userRepository;
    }

    public void Dispose()
    {
        dataContext.Dispose();
    }

    public void SaveChanges()
    {
        dataContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await dataContext.SaveChangesAsync(cancellationToken);
        return result;
    }

}
