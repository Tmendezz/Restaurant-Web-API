using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurants.Domain.Respositories
{
    public interface IDishesRepository
    {
        Task<int> Create(Dish entity);
        
        Task<int> Update(Dish entity);
        Task Delete(IEnumerable<Dish> entities);

    }
}
