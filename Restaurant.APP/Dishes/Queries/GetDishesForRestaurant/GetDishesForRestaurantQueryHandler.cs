using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.App.Dishes.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Respositories;

namespace Restaurants.App.Dishes.Queries.GetDishesForRestaurant
{
    public class GetDishesForRestaurantQueryHandler(ILogger<GetDishesForRestaurantQueryHandler> logger, IRestaurantRepository restaurantRepository, IMapper mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDTO>>
    {
        public async Task<IEnumerable<DishDTO>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving dishes for restaurant with id: {restaurantId}", request.restaurantId);
            var restaurant = await restaurantRepository.GetByIdAsync(request.restaurantId);

            if (restaurant == null) throw new NotFoundException(nameof(Restaurant.Domain.Entities.Restaurant), request.restaurantId.ToString());

            var results = mapper.Map<IEnumerable<DishDTO>>(restaurant.Dishes);
            return results;
        }
    }
}
