
using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;

namespace Restaurant.Application.Users.Commands.Common;

public class UserRoleCommandHandlerBase( UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
{
    protected async Task<User> FindUserByEmail(string email)
    {
        var user = await userManager.FindByEmailAsync(email)
            ?? throw new NotFoundException(nameof(User),email);

        return user;
    }

    protected async Task<IdentityRole> FindRoleByName(string roleName)
    {
        var role = await roleManager.FindByNameAsync(roleName)
            ?? throw new NotFoundException(nameof(IdentityRole),roleName);

        return role;
    }

}
