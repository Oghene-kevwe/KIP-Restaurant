using MediatR;

namespace Restaurant.Application.RestaurantApplication.Commands.EditRestaurant;

public class EditRestaurantCommand: IRequest
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public string? Description { get; set; }
    public bool HasDelivery { get; set; }

}
