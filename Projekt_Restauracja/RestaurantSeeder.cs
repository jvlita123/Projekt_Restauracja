using Projekt_Restauracja.Data;
using Projekt_Restauracja.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Projekt_Restauracja
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect()) //czy polaczenie do bazy moze byc wykonane
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>();
            {
                new Role()
                {
                    Name = "User" //profil roli uzytkownika
                };

                new Role()
                {
                    Name = "Admin"
                };
            }
            return roles;
        }

        private IEnumerable<Restaurant> GetRestaurants() //zwaraca restauracje, które zawsze będą istnieć w tabeli restaurant
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 5.30M,
                        },

                          new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 10.30M,
                        }
                    }

                }

            };

            return restaurants;





        }
    }}