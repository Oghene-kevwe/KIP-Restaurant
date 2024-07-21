using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Dishes.Command.CreateDish;
using Restaurant.Application.Dishes.Command.DeleteDish;
using Restaurant.Application.Dishes.Dto;
using Restaurant.Application.Dishes.Query.GetDishes;
using Restaurant.Application.Dishes.Query.GetSingleDish;
using Restaurant.Infrastructure.Authorization;

namespace Restaurant.Api.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
[ApiController]
[Authorize]
public class DishesController(IMediator mediator):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
       var dishId =  await mediator.Send(command);
        return CreatedAtAction(nameof(GetSingleDish), new {restaurantId, dishId}, null);
    }

    [HttpGet]
    [Authorize(Policy = PolicyNames.AtLeast20)]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllDishes([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetDishesQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId}")]
    [Authorize(Policy = PolicyNames.CreatedAtLeast2)]
    public async Task<ActionResult<DishDto>> GetSingleDish([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetRestaurantSingleDishQuery(restaurantId, dishId));
        return Ok(dish);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDishes([FromRoute] int restaurantId)
    {

         await mediator.Send(new DeleteDishCommand(restaurantId));

        return NoContent();
    }
}
