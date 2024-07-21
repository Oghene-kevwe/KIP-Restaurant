using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Users.Commands.Common;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Users.Commands.UnassignUserRole;

public class UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommandHandler> logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : UserRoleCommandHandlerBase(userManager,roleManager), IRequestHandler<UnassignUserRoleCommand>
{
    private readonly ILogger<UnassignUserRoleCommandHandler> _logger = logger;
    private readonly UserManager<User> _userManager = userManager;
    public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
    {

        _logger.LogInformation("Unassigning user role : {@Request}", request);

        var user = await FindUserByEmail(request.UserEmail);

        var role = await FindRoleByName(request.RoleName);

        await _userManager.RemoveFromRoleAsync(user, role.Name!);

    }
}
