using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories
{
    public interface IRestaurantRepositories
    {
        Task<IEnumerable<Restaurants>> GetAllRestaurantAsync();
        Task<Restaurants> GetRestaurantsByIdAsync(int id);
        Task<int>Create(Restaurants entity);
        Task Delete(Restaurants entity);
        Task SaveChanges();

    }
}
