

using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Infrastructure.Authorization.Requirement.MinimumCreatedRestaurant;

public class MinimumCreatedRestaurant(int minimumRestaurant):IAuthorizationRequirement
{
    public int MinimunCreatedRestaurant { get; } = minimumRestaurant;
}
