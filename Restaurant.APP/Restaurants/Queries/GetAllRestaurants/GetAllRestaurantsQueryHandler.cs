﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.App.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Respositories;
using Restaurants.App.Restaurants.Queries.GetAllRestaurants;
using Restaurants.App.Restaurants.Dtos;

namespace Restaurants.App.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger, IMapper mapper, IRestaurantRepository restaurantRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDTO>>
    {
        public async Task<IEnumerable<RestaurantDTO>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all restaurants.");
            var restaurants = await restaurantRepository.GetAllAsync();

            var restaurantsDTO = mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);

            return restaurantsDTO!;
        }
    }
}
