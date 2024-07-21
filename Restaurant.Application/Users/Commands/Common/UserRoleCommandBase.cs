

using MediatR;

namespace Restaurant.Application.Users.Commands.Common;

public class UserRoleCommandBase:IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
