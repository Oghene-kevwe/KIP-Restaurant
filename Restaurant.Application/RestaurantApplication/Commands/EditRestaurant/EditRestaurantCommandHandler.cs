using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Constants;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.RestaurantApplication.Commands.EditRestaurant;

public class EditRestaurantCommandHandler(ILogger<EditRestaurantCommandHandler> logger, IRestaurantRepositories restaurantRepository, IMapper mapper,
    IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<EditRestaurantCommand>
{
   public  async Task Handle(EditRestaurantCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation("Editing Restaurant with id: {RestaurantId} with {@EditRestaurant}", request.Id,request);

        var restaurant = await restaurantRepository.GetRestaurantsByIdAsync(request.Id);

        if(restaurant == null)
            throw new NotFoundException(nameof(Restaurants), request.Id.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update))
            throw new ForbidException();

        mapper.Map(request, restaurant);

       await restaurantRepository.SaveChanges();

    }
}
