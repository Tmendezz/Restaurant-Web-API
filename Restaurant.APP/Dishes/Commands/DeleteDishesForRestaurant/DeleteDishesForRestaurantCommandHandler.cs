using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurants.App.Dishes.Dtos;
using Restaurants.App.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Respositories;

namespace Restaurants.App.Dishes.Commands.DeleteAllDishes
{
    public class DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommand> logger, IMapper mapper, IRestaurantRepository restaurantRepository,
        IDishesRepository dishesRepository) : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogWarning("Deleting dishes for restaurant with id {RestaurantId}", request.RestaurantId);

            var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Restaurant.Domain.Entities.Restaurant), request.RestaurantId.ToString());
            }

            await restaurantRepository.Delete(dishes);
            return restaurant;
        }
    }
}
