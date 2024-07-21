using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Users;


namespace Restaurant.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtension).Assembly;

        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddAutoMapper(applicationAssembly);
        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();

        services.AddScoped<IUserContext , UserContext>();

        services.AddHttpContextAccessor();  

        
    }
}
