using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_Restauracja;
using Projekt_Restauracja.Data;

namespace Projekt_Restauracja.Pages.AddCategoryGroup
{
    public class EditModel : PageModel
    {
        private readonly Projekt_Restauracja.Data.RestaurantDbContext _context;

        public EditModel(Projekt_Restauracja.Data.RestaurantDbContext context)
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
           ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
           ViewData["DishId"] = new SelectList(_context.Dish, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CategoryGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryGroupExists(CategoryGroup.DishId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CategoryGroupExists(int id)
        {
            return _context.CategoryGroup.Any(e => e.DishId == id);
        }
    }
}
