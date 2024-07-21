

using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;

public interface IDishesRepository
{
    Task<int> CreateDish(Dish entity); 
    Task DeleteDish(IEnumerable<Dish> entities);   
}
