using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Dishes.Command.CreateDish;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger, IRestaurantRepositories repository, IDishesRepository dishesRepository, IMapper mapper,
    IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<CreateDishCommand,int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new Dish {@DishRequest}", request);
        var restaurant = await repository.GetRestaurantsByIdAsync(request.RestaurantId);
        if(restaurant == null) throw new NotFoundException(nameof(Restaurants),request.RestaurantId.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update))
            throw new ForbidException();

        var dish = mapper.Map<Dish>(request);

        return await dishesRepository.CreateDish(dish);
    }
}
