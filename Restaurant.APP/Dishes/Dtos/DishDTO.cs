﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurants.App.Dishes.Dtos
{
    public class DishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }
        
        public static DishDTO FromEntity(Dish dish)
        {
            return new DishDTO()
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                KiloCalories = dish.KiloCalories
            };
        }
    }
}
