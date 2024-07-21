using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Users.Commands.AssignUserRole;
using Restaurant.Application.Users.Commands.UnassignUserRole;
using Restaurant.Application.Users.Commands.UpdateUserDetails;
using Restaurant.Domain.Constants;

namespace Restaurant.Api.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController( IMediator mediator ) : ControllerBase
{
    [HttpPatch("user")]
    [Authorize]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
    {
        await mediator.Send(command);

        return NoContent(); 
    }

    [HttpPatch("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("removeUserRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UassignUserRole(  UnassignUserRoleCommand command)
    {
        await mediator.Send(command);

        return NoContent();
    }
}
