using FluentValidation;
using Restaurant.Application.RestaurantApplication.Dtos;

namespace Restaurant.Application.RestaurantApplication.Commands.CreateRestaurant;
public class CreateRestaurantValidators : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "Lagosian"];
    public CreateRestaurantValidators()
    {
        RuleFor(dto => dto.Name).Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.Category)
            .Must(validCategories.Contains)
            .WithMessage("Enter Valid category");


        RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Please enter valid email address");

    }
}
