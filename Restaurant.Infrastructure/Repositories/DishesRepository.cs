

using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Persistence;

namespace Restaurant.Infrastructure.Repositories;

internal class DishesRepository(RestaurantDbContext dbContext) : IDishesRepository
{
    public async Task<int> CreateDish(Dish entity)
    {
        dbContext.Dishes.Add(entity);
       await  dbContext.SaveChangesAsync();
        return entity.Id;   
    }

   

    public async Task DeleteDish(IEnumerable<Dish> entities)
    {
        dbContext.Dishes.RemoveRange(entities);
        await dbContext.SaveChangesAsync();


    }
}
