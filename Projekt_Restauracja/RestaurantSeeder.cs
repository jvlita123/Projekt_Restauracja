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
         

                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

      

        private IEnumerable<Restaurant> GetRestaurants() //zwaraca restauracje, które zawsze będą istnieć w tabeli restaurant
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "Zagłoba",
                    Description = "Restauracja Zagłoba to wyjątkowe miejsce ulokowane " +
                    "w sercu Kamiennej Góry. Na dwóch stylowo urządzonych piętrach " +
                    "serwujemy szereg klasycznych polskich potraw," +
                    " które łączą kulinarną wiedzę naszego szefa " +
                    "kuchni ze świeżymi sezonowymi składnikami. W naszym " +
                    "menu znajdą państwo dania na każdą okazję, " +
                    "od specjalnych rocznic po spotkania okolicznościowe lub po" +
                    " prostu wspaniały obiad z rodziną. Dążymy do tego, aby stworzyć" +
                    " atrakcyjne wrażenia smakowe dla każdego z naszych gości.",

                    ContactEmail = "contact@Zagloba.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Pizza Włoska",
                            Price = 23,
                            Description = " potrawa kuchni włoskiej, obecnie szeroko" +
                            " rozpowszechniona na całym świecie. " +
                            "Jest to płaski placek z ciasta drożdżowego " +
                            "(focaccia), z sosem pomidorowym, posypany tartym serem " +
                            "(najczęściej jest to mozzarella)" +
                            " i ziołami, pieczony w bardzo mocno nagrzanym piecu. " +
                            "Pizzę podaje się na gorąco, " +
                            "lecz rozpowszechnione jest jedzenie jej również na zimno.",                            
                        },

                          new Dish()
                        {
                            Name = "Espresso",
                            Price = 13,
                            Description = "Espresso parzy się zazwyczaj z mieszanek kilku gatunków kaw" +
                            ". Powstała w ten sposób kawa ma" +
                            " (po prawidłowym przygotowaniu) gęstą, orzechowobrązową " +
                            "piankę zwaną z wł. crema. Piance tej espress" +
                            "o zawdzięcza dużą część swego aromatu. Dzięki krótkiemu czasowi ekstrakcji, ",

                        }
                    }

                }

            };

            return restaurants;





        }
    }
}