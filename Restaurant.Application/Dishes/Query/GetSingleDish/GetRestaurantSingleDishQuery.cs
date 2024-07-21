

using MediatR;
using Restaurant.Application.Dishes.Dto;

namespace Restaurant.Application.Dishes.Query.GetSingleDish;

public class GetRestaurantSingleDishQuery(int restaurantId, int dishId):IRequest<DishDto>
{
    public int RestaurantId { get; } = restaurantId;
    public int DishId { get; } = dishId;

}
