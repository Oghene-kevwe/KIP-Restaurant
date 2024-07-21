

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Users;

namespace Restaurant.Infrastructure.Authorization.Requirement.MinimumAgeRequirement;

public class MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirement> logger,
    IUserContext userContext) : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var currentUser = userContext.GetCurrentUser();
        var dob = context.User.Claims.FirstOrDefault(c => c.Type == "");

        logger.LogInformation("User {Email}, date of birth {DOB} Handling MinimumAgeRequirement",
            currentUser.Email, currentUser.DateOfBirth);


        if (currentUser.DateOfBirth == null)
        {
            logger.LogWarning("User date of birth is null");
            context.Fail();
            return Task.CompletedTask;
        }

        if (currentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Today))
        {
            logger.LogInformation("Authorization Succeeded");
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }


        return Task.CompletedTask;
    }
}
