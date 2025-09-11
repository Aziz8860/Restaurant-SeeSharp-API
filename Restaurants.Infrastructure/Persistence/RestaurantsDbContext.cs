using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence;

internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
{
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);
        // ngasih tau kalau Address itu punyanya Restaurant Entity (bukan entity terpisah)
        // You use .OwnsOne when you have an object(like Address) that makes sense only as
        // part of a parent entity(Restaurant), not independently.

        modelBuilder.Entity<Restaurant>()
           .HasMany(r => r.Dishes)
           .WithOne()
           .HasForeignKey(d => d.RestaurantId);
        // sets up a standard one-to-many FK relationship (Restaurant → Dishes).
    }
}

