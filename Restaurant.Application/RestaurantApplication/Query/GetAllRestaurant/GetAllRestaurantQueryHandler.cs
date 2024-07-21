

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.RestaurantApplication.Dtos;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.RestaurantApplication.Query.GetAllRestaurant;
public class GetAllRestaurantQueryHandler(IRestaurantRepositories restaurantRepository, ILogger<GetAllRestaurantQueryHandler> logger, IMapper mapper) : IRequestHandler<GetAllRestaurantQuery, IEnumerable<RestaurantDto>>
{
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantRepository.GetAllRestaurantAsync();
        var restaurantDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantDto!;
    }
}
