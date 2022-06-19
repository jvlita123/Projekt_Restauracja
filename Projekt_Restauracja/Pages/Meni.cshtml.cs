using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Projekt_Restauracja.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Restauracja.Pages
{
    public class Meni : PageModel
    {
        private Data.RestaurantDbContext _context { get; set; }
        public IList<Dish> Dishes { get; set; }
        public Dish Dish { get; set; }



        public Meni(Projekt_Restauracja.Data.RestaurantDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            if (Dishes != null)
                _context.Dish.Add(Dish);
            Dishes = _context.Dish.ToList();


        }
      
     

    }
}
