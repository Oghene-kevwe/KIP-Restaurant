

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Dishes.Dto;
using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Dishes.Command.DeleteDish;

public class DeleteDishCommandHandler(IRestaurantRepositories repository, ILogger<DeleteDishCommandHandler> logger,IDishesRepository dishesRepository,IMapper mapper,
    IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<DeleteDishCommand>
{
    public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Deleting all dishes from restaurant with id: {restaurantId}", request.RestaurantId);

        var restaurant = await repository.GetRestaurantsByIdAsync(request.RestaurantId);
        if (restaurant == null) throw new NotFoundException(nameof(Restaurants), request.RestaurantId.ToString() );

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update))
            throw new ForbidException();

        await dishesRepository.DeleteDish(restaurant.Dishes);
        

    }
}
