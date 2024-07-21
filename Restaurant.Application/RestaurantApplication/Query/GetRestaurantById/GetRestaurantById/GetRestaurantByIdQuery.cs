

using MediatR;
using Restaurant.Application.RestaurantApplication.Dtos;

namespace Restaurant.Application.RestaurantApplication.Query.GetRestaurantById.GetRestaurantById;

public class GetRestaurantByIdQuery (int id):IRequest<RestaurantDto>
{
    public int Id { get; } = id;
}
