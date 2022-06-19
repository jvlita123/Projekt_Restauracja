using Microsoft.AspNetCore.Identity;
using Projekt_Restauracja.Data;
using Projekt_Restauracja.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekt_Restauracja.Services
{

    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _restaurantContext;
        IList<Dish> Dishes { get; set; }

        public DishService(RestaurantDbContext restaurantContext)
        {
            _restaurantContext = restaurantContext;
        }
        public IQueryable<Dish> GetDishes()
        {
            return _restaurantContext.Dish;
        }
        public IQueryable<Category> AddCategory()
        {
            Category cat = new Category();
            cat.Name = "Kawka";
            _restaurantContext.Category.Add(cat); 
            _restaurantContext.SaveChanges();

            return _restaurantContext.Category; 

        }




    }
}

