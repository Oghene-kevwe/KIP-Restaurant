using Microsoft.Extensions.Logging;
using Restaurant.Application.Users;
using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Infrastructure.Authorization.Services;

public class RestaurantAuthorizationService(ILogger<RestaurantAuthorizationService> logger, IUserContext userContext) : IRestaurantAuthorizationService
{
    public bool Authorize(Restaurants restaurant, ResourceOperation resourceOperation)
    {
        var user = userContext.GetCurrentUser();

        logger.LogInformation("Authorizing user {UserEmail} to {Operation} for restaurant {Restaurant}", user.Email,
            resourceOperation,
            restaurant.Name);

        if (resourceOperation == ResourceOperation.Read || resourceOperation == ResourceOperation.Create)
        {
            logger.LogInformation("Create/Read operation -  successful authorization");

            return true;
        }

        if (resourceOperation == ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Admin user, delete operation -  successful authorization");

            return true;
        }

        if (resourceOperation == ResourceOperation.Delete || resourceOperation == ResourceOperation.Update && user.id == restaurant.OwnerId)
        {
            logger.LogInformation("Restaurant owner -  successful authorization");

            return true;
        }

        return false;




    }
}
