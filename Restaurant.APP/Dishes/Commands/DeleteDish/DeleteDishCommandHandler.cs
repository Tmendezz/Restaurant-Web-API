using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Respositories;

namespace Restaurants.App.Dishes.Commands.DeleteDish
{
    public class DeleteDishCommandHandler(ILogger<DeleteDishCommandHandler> logger, IMapper mapper, IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteDishCommand>
    {
        public Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
