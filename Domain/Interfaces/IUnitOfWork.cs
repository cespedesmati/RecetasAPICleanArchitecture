namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookMarkRepository BookMarkRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IIngredientRepository IngredientRepository { get; }
        IIngredientUsedRepository IngredientUsedRepository { get; }
        IRecipeRepository RecipeRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IStepRepository StepRepository { get; }
        IUnitRepository UnitRepository { get; }
        IUserRepository UserRepository { get; }
        void SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
