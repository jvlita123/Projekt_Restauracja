using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Restauracja
{
    public class Restaurant
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDelivery { get; set; }
        public string ContactEmail { get; set; }

        public virtual List<Dish> Dishes { get; set; }


    }
}
