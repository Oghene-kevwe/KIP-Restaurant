using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.RestaurantApplication.Dtos;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.RestaurantApplication.Query.GetRestaurantById.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(IRestaurantRepositories restaurantRepository, ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting a single restaurant {RestaurantId}", request.Id);
        var singleRestaurant = await restaurantRepository.GetRestaurantsByIdAsync(request.Id) ??
                       throw new NotFoundException(nameof(Restaurants), request.Id.ToString());


        var singleRestaurantDto = mapper.Map<RestaurantDto>(singleRestaurant);
        return singleRestaurantDto;
    }
}
