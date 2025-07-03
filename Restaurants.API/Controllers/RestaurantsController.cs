using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.App.Restaurants;
using Restaurants.App.Restaurants.Commands.CreateRestaurant;
using Restaurants.App.Restaurants.Commands.DeleteRestaurant;
using Restaurants.App.Restaurants.Commands.UpdateRestaurtant;
using Restaurants.App.Restaurants.Dtos;
using Restaurants.App.Restaurants.Queries.GetAllRestaurants;
using Restaurants.App.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers
{
    [ApiController]
    
    [Route("api/restaurants")]
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetAll()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDTO>> GetById([FromRoute]int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            return Ok(restaurant);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            await mediator.Send(new DeleteRestaurantCommand(id));
            return NoContent();   
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new {id}, null);
        }


    }
}
