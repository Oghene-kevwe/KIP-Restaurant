using Restaurant.Api.Extensions;
using Restaurant.Api.Middlewares;
using Restaurant.Application.Extensions;
using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Extensions;
using Restaurant.Infrastructure.Seeders;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

// invoke restaurant seeder - seeder is added after building app
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<LogRequestTimeMiddleware>();


app.UseSerilogRequestLogging();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
