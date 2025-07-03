using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.App.Restaurants.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Respositories;

namespace Restaurants.App.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper, IRestaurantRepository restaurantRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDTO>
    {
        public async Task<RestaurantDTO> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting restaurant {RestaurantId}", request.Id);
            var restaurant = await restaurantRepository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(nameof(Restaurant.Domain.Entities.Restaurant), request.Id.ToString());

            var restaurantDTO = mapper.Map<RestaurantDTO>(restaurant);

            return restaurantDTO;
        }
    }
}
