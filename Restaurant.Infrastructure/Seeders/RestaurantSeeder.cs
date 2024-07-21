using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Persistence;

namespace Restaurant.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {

            var restaurants = GetRestaurants();
            dbContext.Restaurants.AddRange(restaurants);
            await dbContext.SaveChangesAsync();
        }

            if(!dbContext.Roles.Any())
            {
                var roles = GetRoles(); 
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }

            }
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
             [
                new (UserRoles.User){
                    NormalizedName = UserRoles.User.ToUpper()
                },
                new (UserRoles.Owner){
                    NormalizedName = UserRoles.Owner.ToUpper()

                },
                new (UserRoles.Admin){
                    NormalizedName = UserRoles.Admin.ToUpper()

                },
            ];
        return roles;
    }

    private IEnumerable<Restaurants> GetRestaurants()
    {
        List<Restaurants> restaurant = [
            new () {
                Name= "KFC",
                Category ="Fast Food",
                Description = "Kentucky Fried Chicken",
                ContactEmail = "kentucky@gmail.com",
                ContactNumber = "08012345678",
                HasDelivery = true,
                Dishes = [
                    new (){
                        Name = "Eggs",
                        Description = "Fried Eggs in low heat",
                        Price = 5.45M

                    }
                    ],
               Address = new (){
                   CityName = "New York",
                   StreetName = "No 20 NY Lane",
                   PostalCode = "390002"

               }
            },
            new (){
                 Name= "Cakes and Pastries",
                Category ="Fast Food",
                Description = "Cakes and Gifts",
                ContactEmail = "cakesandpastries@gmail.com",
                ContactNumber = "08012334322",
                HasDelivery = true,

               Address = new (){
                   CityName = "Akure",
                   StreetName = "South Gate road",
                   PostalCode = "982002"

               }
            }
            ];

        return restaurant;
    }
}
