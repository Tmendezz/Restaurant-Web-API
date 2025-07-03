using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastructure.Persistance;
using Restaurants.Domain.Respositories;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantRepository(RestaurantsDbContext dbContext) : IRestaurantRepository
    {
        public async Task<int> Create(Restaurant.Domain.Entities.Restaurant entity)
        {
            dbContext.Restaurants.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Restaurant.Domain.Entities.Restaurant entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public Task Update()
        => dbContext.SaveChangesAsync();

        public async Task<IEnumerable<Restaurant.Domain.Entities.Restaurant>> GetAllAsync()
        {
            var restaurants = await dbContext.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant.Domain.Entities.Restaurant?> GetByIdAsync(int id)
        {
            var restaurant = await dbContext.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(x => x.Id == id);
            return restaurant;
        }
    }
}
