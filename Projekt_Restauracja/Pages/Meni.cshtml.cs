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
        private readonly IDishService _dishService;
        public IQueryable<Dish> Records { get; set; }
        public IQueryable<Category> Category { get; set; }
        public string SearchTerm { get; set; } 

        public Meni(IDishService dishService)
        {
           
            _dishService = dishService;
        }
        public void OnGet()
        {
            Category = _dishService.AddCategory();
            Records = _dishService.GetDishes();
        }
    }

     

    
}
