using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt_Restauracja;
using Projekt_Restauracja.Data;

namespace Projekt_Restauracja.Pages.AddCategoryGroup
{
    public class IndexModel : PageModel
    {
        private readonly Projekt_Restauracja.Data.RestaurantDbContext _context;

        public IndexModel(Projekt_Restauracja.Data.RestaurantDbContext context)
        {
            _context = context;
        }

        public IList<CategoryGroup> CategoryGroup { get;set; }

        public async Task OnGetAsync()
        {
            CategoryGroup = await _context.CategoryGroup
                .Include(c => c.Category)
                .Include(c => c.Dish).ToListAsync();
        }
    }
}
