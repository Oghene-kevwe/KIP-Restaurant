using MediatR;

namespace Restaurant.Application.RestaurantApplication.Commands.CreateRestaurant;

public class CreateRestaurantCommand: IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactNumber { get; set; }

    public string? CityName { get; set; }
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }
}
