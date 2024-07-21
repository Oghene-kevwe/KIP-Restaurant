using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Users;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.RestaurantApplication.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(IRestaurantRepositories restaurantRepository, ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();

            logger.LogInformation(" {User} with id: {UserId} is creating a new restaurant {@Restaurant}",
                currentUser.Email, 
                currentUser.id, 
                request);

            var restaurant = mapper.Map<Restaurants>(request);
            restaurant.OwnerId = currentUser.id;

            int id = await restaurantRepository.Create(restaurant);
            return id;
        }
    }
}
 