using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Respositories;

namespace Restaurants.App.Dishes.Commands.CreateDish
{
    internal class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger, IMapper mapper, IRestaurantRepository restaurantRepository, 
        IDishesRepository dishesRepository) : IRequestHandler<CreateDishCommand>
    {
        public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new dish: {@DishRequest}", request);
            var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException(nameof(Restaurant.Domain.Entities.Restaurant), request.RestaurantId.ToString());

            var dish = mapper.Map<Dish>(request);
            await dishesRepository.Create(dish);
        }
    }
}
