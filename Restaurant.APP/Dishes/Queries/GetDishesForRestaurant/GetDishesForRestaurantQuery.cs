using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Restaurants.App.Dishes.Dtos;

namespace Restaurants.App.Dishes.Queries.GetDishesForRestaurant
{
    public class GetDishesForRestaurantQuery(int restaurantId) : IRequest<IEnumerable<DishDTO>>
    {
        public int restaurantId { get; } = restaurantId;
    }
}
