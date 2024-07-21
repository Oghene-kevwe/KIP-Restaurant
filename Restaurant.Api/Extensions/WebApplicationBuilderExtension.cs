using Microsoft.OpenApi.Models;
using Restaurant.Api.Middlewares;
using Serilog;

namespace Restaurant.Api.Extensions;

public static class WebApplicationBuilderExtension
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {

            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
            },
            []
        }
    });

        });

        //serilog
        builder.Host.UseSerilog((context, configuration) =>
             configuration
            .ReadFrom.Configuration(context.Configuration)
        );

        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<LogRequestTimeMiddleware>();
    }
}
