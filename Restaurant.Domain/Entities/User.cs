
using Microsoft.AspNetCore.Identity;

namespace Restaurant.Domain.Entities;

public class User:IdentityUser
{
    public DateOnly? DateofBirth { get; set; }  
    public string? Nationality { get; set; }

    public List<Restaurants> OwnedRestaurants { get; set; } = []; 
}
