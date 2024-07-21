

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Users.Commands.Common;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Users.Commands.AssignUserRole;

public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : UserRoleCommandHandlerBase(userManager, roleManager),IRequestHandler<AssignUserRoleCommand>
{
    private readonly ILogger<AssignUserRoleCommandHandler> _logger = logger;
    private readonly UserManager<User> _userManager = userManager;

    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Assigning user role:{@Request}", request);

        var user = await FindUserByEmail(request.UserEmail);
       
        var role = await FindRoleByName(request.RoleName);

        await _userManager.AddToRoleAsync(user, role.Name!);

    }
}
