using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Projekt_Restauracja.Data;
using System.Collections.Generic;
using System.Linq;

namespace Projekt_Restauracja.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDishService _dishService;

        private readonly RestaurantDbContext _context;
        public IList<Dish> Dishes { get; set; }
        public IList<Restaurant> Restaurants { get; set; }
        public IndexModel(ILogger<IndexModel> logger, RestaurantDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public void OnGet()
        {
            Dishes = _context.Dish.ToList();
            Restaurants = _context.Restaurants.ToList();


        }
        [BindProperty]
        public Dish Dish { get; set; }


        public IActionResult OnPost()
        {
            Dishes = _context.Dish.ToList();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Dish.Add(Dish);
            _context.Dish.Add(Dish);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

    }
}
