using Application.Services;
using Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        services.AddScoped<IRecipeService, RecipeService>();
        services.AddScoped<IUserService, UserService>();


        services.AddTransient<ICurrentUserService, CurrentUserService>();
        return services;


    }
}
