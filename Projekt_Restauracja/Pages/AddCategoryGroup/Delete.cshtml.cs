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
    public class DeleteModel : PageModel
    {
        private readonly Projekt_Restauracja.Data.RestaurantDbContext _context;

        public DeleteModel(Projekt_Restauracja.Data.RestaurantDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryGroup CategoryGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryGroup = await _context.CategoryGroup
                .Include(c => c.Category)
                .Include(c => c.Dish).FirstOrDefaultAsync(m => m.DishId == id);

            if (CategoryGroup == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryGroup = await _context.CategoryGroup.FindAsync(id);

            if (CategoryGroup != null)
            {
                _context.CategoryGroup.Remove(CategoryGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
