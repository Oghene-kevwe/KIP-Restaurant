
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Dishes.Dto;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Dishes.Query.GetDishes;

public class GetDishesQueryHandler(ILogger<GetDishesQueryHandler> logger, IRestaurantRepositories repository, IMapper mapper) : IRequestHandler<GetDishesQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetDishesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving all dishes for restaurant with id: {RestaurantId}", request.RestaurantId);
            var restaurant =  await repository.GetRestaurantsByIdAsync(request.RestaurantId);

        if (restaurant == null) throw new NotFoundException(nameof(Restaurants),request.RestaurantId.ToString());

        var results =  mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

        return results;
    }
}
