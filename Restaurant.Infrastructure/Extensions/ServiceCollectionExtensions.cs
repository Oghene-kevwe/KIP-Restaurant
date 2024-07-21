using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Authorization;
using Restaurant.Infrastructure.Authorization.Requirement.MinimumAgeRequirement;
using Restaurant.Infrastructure.Authorization.Requirement.MinimumCreatedRestaurant;
using Restaurant.Infrastructure.Authorization.Services;
using Restaurant.Infrastructure.Persistence;
using Restaurant.Infrastructure.Repositories;
using Restaurant.Infrastructure.Seeders;

namespace Restaurant.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantDb");
        services.AddDbContext<RestaurantDbContext>(option=>option.UseSqlServer(connectionString)
        .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<RestaurantsUserClaimsPrincipalFactory>()
            .AddEntityFrameworkStores<RestaurantDbContext>();

        //register restaurant seeder
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder >();

        //register get all restaurant interface
        services.AddScoped<IRestaurantRepositories, RestaurantRepository>();
        services.AddScoped<IDishesRepository,DishesRepository>();
        services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.HasNationality, builder => builder.RequireClaim(AppClaimType.Nationality, "Brazillian"))
            .AddPolicy(PolicyNames.AtLeast20, builder => builder.AddRequirements(new MinimumAgeRequirement(20)))
            .AddPolicy(PolicyNames.CreatedAtLeast2, builder => builder.AddRequirements(new MinimumCreatedRestaurant(2)));
        

        services.AddScoped<IAuthorizationHandler,MinimumAgeRequirementHandler>();
        services.AddScoped<IAuthorizationHandler, MinimumCreatedRestaurantHandler>();

        services.AddScoped<IRestaurantAuthorizationService,RestaurantAuthorizationService>();


    }
}
