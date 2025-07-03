using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Persistance
{
    internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
    {
        internal DbSet<Restaurant.Domain.Entities.Restaurant> Restaurants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant.Domain.Entities.Restaurant>()
                .OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant.Domain.Entities.Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);
        }
    }
}
