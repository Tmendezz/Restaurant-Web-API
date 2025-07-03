﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Restaurants.App.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand(int id) : IRequest
    {
        public int Id { get; } = id;
    }
}
