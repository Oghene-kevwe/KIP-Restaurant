

using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.RestaurantApplication.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IRestaurantRepositories restaurantRepository,IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting restaurant with id: {RestaurantId}", request.Id);
        var restaurant = await restaurantRepository.GetRestaurantsByIdAsync(request.Id);

        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurants), request.Id.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Delete))
            throw new ForbidException();


        await restaurantRepository.Delete(restaurant);
    }
}
