using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistence
{
    internal class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : IdentityDbContext<User>(options)
    {
        internal DbSet<Restaurants> Restaurants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurants>().OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurants>().HasMany(r => r.Dishes).WithOne().HasForeignKey(d => d.RestaurantId);

            modelBuilder.Entity<User>()
                .HasMany(o=>o.OwnedRestaurants)
                .WithOne(r=>r.Owner)
                .HasForeignKey(r=>r.OwnerId);
        }
    }

}
