using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Interfaces;

public interface IRestaurantAuthorizationService
{
    bool Authorize(Restaurants restaurant, ResourceOperation resourceOperation);
}
