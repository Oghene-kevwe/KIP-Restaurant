

using MediatR;

namespace Restaurant.Application.RestaurantApplication.Commands.DeleteRestaurant;

public class DeleteRestaurantCommand(int id):IRequest
{
    public int Id { get; } = id;
}
