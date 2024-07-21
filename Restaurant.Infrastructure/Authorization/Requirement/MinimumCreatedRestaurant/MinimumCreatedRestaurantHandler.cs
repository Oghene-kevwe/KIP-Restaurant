

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Users;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Persistence;

namespace Restaurant.Infrastructure.Authorization.Requirement.MinimumCreatedRestaurant;

public class MinimumCreatedRestaurantHandler(ILogger<MinimumCreatedRestaurantHandler> logger,
    IUserContext userContext, IRestaurantRepositories restaurantRepository) : AuthorizationHandler<MinimumCreatedRestaurant>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumCreatedRestaurant requirement)
    {
        var currentUser = userContext.GetCurrentUser();

        logger.LogInformation("Checking number of Restaurant created by user {UserEmail}", currentUser.Email);

        var restaurants = await restaurantRepository.GetAllRestaurantAsync();
        var userCreatedRestaurant = restaurants.Count(r => r.OwnerId == currentUser!.id);


        if (userCreatedRestaurant >= requirement.MinimunCreatedRestaurant)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }
}
