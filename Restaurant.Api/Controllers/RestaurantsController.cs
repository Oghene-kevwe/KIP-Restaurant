using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.RestaurantApplication;
using Restaurant.Application.RestaurantApplication.Commands.CreateRestaurant;
using Restaurant.Application.RestaurantApplication.Commands.DeleteRestaurant;
using Restaurant.Application.RestaurantApplication.Commands.EditRestaurant;
using Restaurant.Application.RestaurantApplication.Dtos;
using Restaurant.Application.RestaurantApplication.Query.GetAllRestaurant;
using Restaurant.Application.RestaurantApplication.Query.GetRestaurantById.GetRestaurantById;
using Restaurant.Domain.Constants;
using Restaurant.Infrastructure.Authorization;

namespace Restaurant.Api.Controllers;

[ApiController]
    [Route("api/restaurants")]
[Authorize]

public class RestaurantsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async  Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantQuery());
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = PolicyNames.HasNationality)]
    public async Task<ActionResult<RestaurantDto?>> GetById([FromRoute] int id)
    {
        var singleRestaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        if (singleRestaurant == null)
        {
            return BadRequest("Restaurant not found.");
        }
        return Ok(singleRestaurant);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
         await mediator.Send(new DeleteRestaurantCommand(id));
         
            return NoContent();
        
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Owner)]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
    {
        int id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, null);
     }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> EditRestaurant([FromRoute] int id,  EditRestaurantCommand command )
    {
        command.Id = id;
          await mediator.Send(command);
       
            return NoContent();
    }
}
 