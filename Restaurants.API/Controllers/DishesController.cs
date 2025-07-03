using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.App.Dishes.Dtos;
using Restaurants.App.Dishes.Commands.CreateDish;
using Restaurants.App.Dishes.Commands.DeleteDish;
using Restaurants.App.Dishes.Commands.UpdateDish;
using Restaurants.App.Restaurants.Dtos;
using Restaurants.App.Dishes.Queries.GetAllDishes;
using Restaurants.App.Dishes.Queries.GetDishById;
using Restaurants.App.Dishes.Queries.GetDishesForRestaurant;
using Restaurants.App.Dishes.Queries.GetDishByIdForRestaurant;
using Restaurants.App.Dishes.Commands.DeleteAllDishes;

namespace Restaurants.API.Controllers
{
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        //[HttpGet("/api/restaurants/dishes")]
        //public async Task<ActionResult<IEnumerable<DishDTO>>> GetAll()
        //{
        //    var dishes = await mediator.Send(new GetAllDishesQuery());
        //    return Ok(dishes);
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDTO>>> GetAllForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDTO>> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
            return Ok(dish);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<DishDTO>> GetById([FromRoute] int id)
        //{
        //    var dish = await mediator.Send(new GetDishByIdQuery(id));
        //    return Ok(dish);
        //}

        //[HttpPatch("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> UpdateDish([FromRoute] int id, [FromBody] UpdateDishCommand command)
        //{
        //    command.Id = id;
        //    await mediator.Send(command);
        //    return NoContent();
        //}

        [HttpDelete]
        public async Task<IActionResult> DeleteDishesForRestaurant([FromRoute] int restaurantId)
        {
            await mediator.Send((object)new DeleteDishesForRestaurantCommand(restaurantId));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            command.RestaurantId = restaurantId;
            await mediator.Send(command);
            return Created();
        }


    }
}
