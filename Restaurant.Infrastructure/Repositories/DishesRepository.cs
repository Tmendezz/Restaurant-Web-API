using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Persistance;
using Restaurants.Domain.Respositories;

namespace Restaurants.Infrastructure.Repositories
{
    internal class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository
    {
        public async Task<int> Create(Dish entity)
        {
            dbContext.Dishes.Add(entity);
            dbContext.SaveChangesAsync();
            return entity.Id;   
        }

        public async Task Delete(IEnumerable<Dish> entities)
        {
            dbContext.RemoveRange(entities);
            await dbContext.SaveChangesAsync();
        }

        public Task<int> Update(Dish entity)
        {
            throw new NotImplementedException();
        }


    }
}
