using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt_Restauracja;
using Projekt_Restauracja.Data;

namespace Projekt_Restauracja.Pages.CategoryGroupDish
{
    public class IndexModel : PageModel
    {
        private readonly Projekt_Restauracja.Data.RestaurantDbContext _context;
        private readonly IDishService _dishService;

        public IList<CategoryGroup> CategoryGroup { get; set; }
        public IList<Category> Categories { get; set; }
        public IQueryable<Dish> Dishes { get; set; }
        public IndexModel(Projekt_Restauracja.Data.RestaurantDbContext context, IDishService dishService)
        {
            _context = context;
            _dishService = dishService;
        }

        public async Task OnGetAsync()
        {
            CategoryGroup = await _context.CategoryGroup
                .Include(c => c.Category)
                .Include(c => c.Dish).ToListAsync();
            Dishes = _dishService.GetDishes();
        }


    }
}
