﻿

using FluentValidation;

namespace Restaurant.Application.Dishes.Command.CreateDish;

public class CreateDishCommandValidator: AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(dish => dish.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price must be a non negative number");

        RuleFor(dish => dish.KiloCalories)
           .GreaterThanOrEqualTo(0)
           .WithMessage("Kilo Calories must be a non negative number");
    }
}
