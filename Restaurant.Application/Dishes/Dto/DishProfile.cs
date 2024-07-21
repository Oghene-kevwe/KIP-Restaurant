using AutoMapper;
using Restaurant.Application.Dishes.Command.CreateDish;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Dishes.Dto;

public class DishProfile:Profile
{
    public DishProfile()
    {
        CreateMap<CreateDishCommand, Dish>();
        CreateMap<Dish,DishDto>();  
    }
}
