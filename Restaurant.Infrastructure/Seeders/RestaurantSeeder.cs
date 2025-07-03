using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Infrastructure.Persistance;
using Restaurant.Domain.Entities;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if(await dbContext.Database.CanConnectAsync())
            {
                if(!dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    dbContext.Restaurants.AddRange(restaurants);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Restaurant.Domain.Entities.Restaurant> GetRestaurants()
        {
            List<Restaurant.Domain.Entities.Restaurant> restaurants = [
                new()
        {
            Name = "KFC",
            Category = "Fast Food",
            Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky.",
            ContactEmail = "contact@kfc.com",
            HasDelivery = true,
            Dishes =
            [
                new()
                {
                    Name = "Original Recipe Chicken",
                    Description = "Fried chicken seasoned with 11 herbs and spices",
                    Price = 7.99M
                },
                new()
                {
                    Name = "Zinger Burger",
                    Description = "Spicy fried chicken sandwich",
                    Price = 5.49M
                }
            ],
            Address = new Address()
            {
                City = "Louisville",
                Street = "123 Chicken Ave",
                PostalCode = "40202"
            }
        },
        new()
        {
            Name = "La Trattoria",
            Category = "Italian",
            Description = "Authentic Italian cuisine with homemade pasta and wood-fired pizzas.",
            ContactEmail = "info@trattoria.com",
            HasDelivery = false,
            Dishes =
            [
                new()
                {
                    Name = "Spaghetti Carbonara",
                    Description = "Classic Roman pasta with pancetta and egg",
                    Price = 10.50M
                },
                new()
                {
                    Name = "Margherita Pizza",
                    Description = "Tomato, mozzarella, and basil",
                    Price = 9.00M
                }
            ],
            Address = new Address()
            {
                City = "Rome",
                Street = "Via Pasta 45",
                PostalCode = "00100"
            }
        },
        new()
        {
            Name = "Sushi Zen",
            Category = "Japanese",
            Description = "Traditional Japanese sushi bar with fresh fish delivered daily.",
            ContactEmail = "contact@sushizen.com",
            HasDelivery = true,
            Dishes =
            [
                new()
                {
                    Name = "Salmon Nigiri",
                    Description = "Fresh salmon over sushi rice",
                    Price = 4.00M
                },
                new()
                {
                    Name = "Dragon Roll",
                    Description = "Eel and avocado sushi roll",
                    Price = 8.50M
                }
            ],
            Address = new Address()
            {
                City = "Tokyo",
                Street = "1-2 Sushi Street",
                PostalCode = "100-0001"
            }
        },
        new()
        {
            Name = "El Rancho",
            Category = "Mexican",
            Description = "Vibrant Mexican grill with a variety of tacos and burritos.",
            ContactEmail = "hola@elrancho.mx",
            HasDelivery = true,
            Dishes =
            [
                new()
                {
                    Name = "Tacos al Pastor",
                    Description = "Pork marinated with achiote and pineapple",
                    Price = 3.50M
                },
                new()
                {
                    Name = "Burrito de Carne Asada",
                    Description = "Grilled beef with beans and cheese",
                    Price = 6.00M
                }
            ],
            Address = new Address()
            {
                City = "Mexico City",
                Street = "Calle del Taco 789",
                PostalCode = "01000"
            }
        }
    ];

            return restaurants;
        }

    }
}
