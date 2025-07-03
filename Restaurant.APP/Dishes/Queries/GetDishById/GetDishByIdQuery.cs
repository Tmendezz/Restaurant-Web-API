using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Restaurants.App.Dishes.Dtos;

namespace Restaurants.App.Dishes.Queries.GetDishById
{
    public class GetDishByIdQuery(int id) : IRequest<DishDTO>
    {
        internal int Id { get; } = id;
    }
}
