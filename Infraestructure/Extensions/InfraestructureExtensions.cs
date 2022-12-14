using Application.Helpers.Sort;
using Domain.Interfaces;
using Domain.SeedWork;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Helpers;

namespace Infraestructure.Extensions
{
    public static class InfraestructureExtensions
    {
        public static IServiceCollection AddInfraestructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(ConnectionString.GetConnectionString());
            });



            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBookMarkRepository, BookMarkRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IIngredientUsedRepository, IngredientUsedRepository>();
            services.AddScoped<IRecipeSortFactory, RecipeSortFactory>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IStepRepository, StepRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
