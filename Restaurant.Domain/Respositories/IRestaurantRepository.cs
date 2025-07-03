using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurants.Domain.Respositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant.Domain.Entities.Restaurant?>> GetAllAsync();
        Task<Restaurant.Domain.Entities.Restaurant?> GetByIdAsync(int id);
        Task<int> Create(Restaurant.Domain.Entities.Restaurant entity);
        Task Delete(Restaurant.Domain.Entities.Restaurant entity);
        Task Update();
    }
}