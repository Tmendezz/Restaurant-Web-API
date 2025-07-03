using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Respositories;

namespace Restaurants.App.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantRepository restaurantRepository) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new restaurant {@Restaurant.Domain.Entities.Restaurant}", request);

            var restaurant = mapper.Map<Restaurant.Domain.Entities.Restaurant>(request);

            int id = await restaurantRepository.Create(restaurant);
            return id;
        }
    }
}
