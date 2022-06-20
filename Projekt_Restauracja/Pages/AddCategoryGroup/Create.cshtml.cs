using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_Restauracja;
using Projekt_Restauracja.Data;

namespace Projekt_Restauracja.Pages.AddCategoryGroup
{
    [Authorize(Policy = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Projekt_Restauracja.Data.RestaurantDbContext _context;

        public CreateModel(Projekt_Restauracja.Data.RestaurantDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
        ViewData["DishId"] = new SelectList(_context.Dish, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CategoryGroup CategoryGroup { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CategoryGroup.Add(CategoryGroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
