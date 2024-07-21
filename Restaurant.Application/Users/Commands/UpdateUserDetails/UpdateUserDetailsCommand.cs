
using MediatR;

namespace Restaurant.Application.Users.Commands.UpdateUserDetails;

public class UpdateUserDetailsCommand : IRequest
{
    public DateOnly? DateofBirth { get; set; }
    public string? Nationality { get; set; }
}
