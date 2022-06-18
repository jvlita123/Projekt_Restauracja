using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt_Restauracja;
using Projekt_Restauracja.Data;

namespace Projekt_Restauracja.Pages.Announcements
{
    public class DetailsModel : PageModel
    {
        private readonly RestaurantDbContext _context;

        public DetailsModel(RestaurantDbContext context)
        {
            _context = context;
        }

        public Announcement Announcement { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Announcement = await _context.Announcements.FirstOrDefaultAsync(m => m.Id == id);

            if (Announcement == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
