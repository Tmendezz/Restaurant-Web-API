using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Restaurants.App.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Respositories;
using Restaurants.Domain.Exceptions;

namespace Restaurants.App.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting restaurant with id {RestauratnId}", request.Id);

            var restaurant = await restaurantRepository.GetByIdAsync( request.Id );

            if ( restaurant == null )
            {
                throw new NotFoundException(nameof(Restaurant.Domain.Entities.Restaurant), request.Id.ToString());
            }

            await restaurantRepository.Delete(restaurant);
        }

    }
}
