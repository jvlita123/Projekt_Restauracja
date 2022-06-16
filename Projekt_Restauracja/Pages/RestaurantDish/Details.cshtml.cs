using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt_Restauracja;
using Projekt_Restauracja.Data;

namespace Projekt_Restauracja.Pages.RestaurantDish
{
    public class DetailsModel : PageModel
    {
        private readonly Projekt_Restauracja.Data.RestaurantDbContext _context;

        public DetailsModel(Projekt_Restauracja.Data.RestaurantDbContext context)
        {
            _context = context;
        }

        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
