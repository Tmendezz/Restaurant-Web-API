using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Restaurants.App.Restaurants.Dtos;

namespace Restaurants.App.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDTO>
    {
        internal int Id { get; } = id;
    }
}
