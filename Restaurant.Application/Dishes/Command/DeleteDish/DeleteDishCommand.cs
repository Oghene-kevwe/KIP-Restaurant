

using MediatR;

namespace Restaurant.Application.Dishes.Command.DeleteDish;

public class DeleteDishCommand(int restaurantId):IRequest
{
    public int RestaurantId { get; } = restaurantId;
}
