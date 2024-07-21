
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;

namespace Restaurant.Application.Users.Commands.UpdateUserDetails;

public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger,
    IUserContext userContext, IUserStore<User> userStore
    ) : IRequestHandler<UpdateUserDetailsCommand>
{
    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        logger.LogInformation("Updating user: {UserId} with {@Request}", user!.id, request);


        var dbUser = await userStore.FindByIdAsync(user!.id, cancellationToken);

        if (dbUser == null)
        {
            throw new NotFoundException(nameof(User), user!.id);
        }

        dbUser.Nationality = request.Nationality;
        dbUser.DateofBirth = request.DateofBirth;

        await userStore.UpdateAsync(dbUser, cancellationToken);

    }
}
