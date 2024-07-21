using AutoMapper;
using Restaurant.Application.RestaurantApplication.Commands.CreateRestaurant;
using Restaurant.Application.RestaurantApplication.Commands.EditRestaurant;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.RestaurantApplication.Dtos;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {

        CreateMap<EditRestaurantCommand, Restaurants>();

        CreateMap<CreateRestaurantCommand, Restaurants>()
            .ForMember(d => d.Address, opt => opt.MapFrom(src => new Address()
            {
                CityName = src.CityName,
                PostalCode = src.PostalCode,
                StreetName = src.StreetName,

            }))
            ;

        CreateMap<Restaurants, RestaurantDto>()
            .ForMember(d => d.CityName, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.CityName)
            ).ForMember(d => d.StreetName, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.StreetName)).ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));
    }
}
