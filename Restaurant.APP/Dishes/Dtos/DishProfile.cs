using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurants.App.Dishes.Commands.CreateDish;

namespace Restaurants.App.Dishes.Dtos
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<CreateDishCommand, Dish>();
            CreateMap<Dish, DishDTO>();
        }
    }
}
