using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Restauracja.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Dish> Dish { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //dodajemy parę kluczy do tabeli pośredniczącej do relacji many to many
builder.Entity<CategoryGroup>()
.HasKey(pg => new { pg.CategoryId, pg.DishId});
            //w tabeli posredniczacej PersonGroup
            builder.Entity<CategoryGroup>()
            .HasOne<Dish>(pg => pg.Dish) // dla jednej osoby
            .WithMany(p => p.CategoryGroups) // jest wiele PersonGroups
            .HasForeignKey(p => p.CategoryId); // a powizanie jestrealizowane przez klucz obcy PersonId//w tabeli posredniczacej PersonGroup
builder.Entity<CategoryGroup>()
.HasOne<Category>(pg => pg.Category) // dla jednej grupy
.WithMany(g => g.CategoryGroups) // jest wiele PersonGroups
.HasForeignKey(g => g.CategoryId); // a powizanie jest realizowane przez klucz obcy GroupId
}


    }
}
