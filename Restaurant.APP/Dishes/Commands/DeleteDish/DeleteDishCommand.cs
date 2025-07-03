using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Restaurants.App.Dishes.Commands.DeleteDish
{
    public class DeleteDishCommand(int id) : IRequest
    {
        public int Id { get; } = id;
    }
}
