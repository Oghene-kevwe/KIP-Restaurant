using FluentValidation;

namespace Restaurant.Application.RestaurantApplication.Commands.EditRestaurant;

public class EditRestaurantValidators:AbstractValidator<EditRestaurantCommand>
{
    public EditRestaurantValidators()
    {
        RuleFor(dto => dto.Name).Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.HasDelivery)
            .NotNull()
            .WithMessage("HasDelivery must be provided");
    }
}
