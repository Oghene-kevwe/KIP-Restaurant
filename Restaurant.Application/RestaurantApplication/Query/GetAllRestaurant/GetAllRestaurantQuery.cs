

using MediatR;
using Restaurant.Application.RestaurantApplication.Dtos;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.RestaurantApplication.Query.GetAllRestaurant;

public class GetAllRestaurantQuery: IRequest<IEnumerable<RestaurantDto>>
{
}
