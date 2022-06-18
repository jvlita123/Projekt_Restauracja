using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Restauracja.Data;

namespace Projekt_Restauracja.Pages.Announcements
{
    public class CreateModel : PageModel
    {
        private readonly RestaurantDbContext _context;

        public CreateModel(RestaurantDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Announcement Announcement { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Announcements.Add(Announcement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
