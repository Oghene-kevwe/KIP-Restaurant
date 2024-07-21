using Restaurant.Application.Dishes.Dto;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.RestaurantApplication.Dtos;

public class RestaurantDto
{

    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }

    public string? CityName { get; set; }
    public string? StreetName { get; set; }
    public string? PostalCode { get; set; }

    public List<DishDto> Dishes { get; set; } = new List<DishDto>();
}
