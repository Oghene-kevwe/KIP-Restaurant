using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Persistence;

namespace Restaurant.Infrastructure.Repositories;

internal class RestaurantRepository(RestaurantDbContext dbContext) : IRestaurantRepositories
{
    public async Task<int> Create(Restaurants entity)
    {
       dbContext.Restaurants.Add(entity);   
        await dbContext.SaveChangesAsync();
        return entity.Id;   
    }

    public async Task Delete(Restaurants entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();

    }


    public async Task<IEnumerable<Restaurants>> GetAllRestaurantAsync()
    {
        var restaurants = await dbContext.Restaurants.ToListAsync();
        return restaurants;
    }


    public async Task<Restaurants?> GetRestaurantsByIdAsync(int id)
    {
        var singleRestaurant =  await dbContext.Restaurants.Include(r=>r.Dishes)
            .FirstOrDefaultAsync(x=> x.Id == id);
        return singleRestaurant;
    }

    public Task SaveChanges()=> dbContext.SaveChangesAsync();

    
}
