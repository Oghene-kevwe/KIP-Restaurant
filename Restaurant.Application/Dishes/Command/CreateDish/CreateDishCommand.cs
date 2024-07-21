

using MediatR;

namespace Restaurant.Application.Dishes.Command.CreateDish;

public class CreateDishCommand: IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public int? KiloCalories { get; set; }
    public int RestaurantId { get; set; }

}
