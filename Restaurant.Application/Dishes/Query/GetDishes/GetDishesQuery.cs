

using MediatR;
using Restaurant.Application.Dishes.Dto;

namespace Restaurant.Application.Dishes.Query.GetDishes;

public class GetDishesQuery(int restaurantId): IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; } = restaurantId;
}
