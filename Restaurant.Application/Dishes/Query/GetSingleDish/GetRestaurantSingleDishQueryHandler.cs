
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Dishes.Command.CreateDish;
using Restaurant.Application.Dishes.Dto;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Dishes.Query.GetSingleDish;

public class GetRestaurantSingleDishQueryHandler(ILogger<GetRestaurantSingleDishQueryHandler> logger, IRestaurantRepositories repository, IMapper mapper) : IRequestHandler<GetRestaurantSingleDishQuery, DishDto>
{
    public async Task<DishDto> Handle(GetRestaurantSingleDishQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving {DishId} for restaurant with id: {RestaurantId}", request.DishId, request.RestaurantId);

        var restaurant = await repository.GetRestaurantsByIdAsync(request.RestaurantId);

        if (restaurant == null) throw new NotFoundException(nameof(Restaurants), request.RestaurantId.ToString());

        var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
        if(dish == null) throw new NotFoundException(nameof(Dish), request.DishId.ToString());

        var result = mapper.Map<DishDto>(dish); 

        return result;
    }
}
