
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Infrastructure.Authorization.Requirement.MinimumAgeRequirement;

public class MinimumAgeRequirement(int minimumAge) : IAuthorizationRequirement
{
    public int MinimumAge { get; } = minimumAge;
}
