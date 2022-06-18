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
    public class IndexModel : PageModel
    {
        private readonly RestaurantDbContext _context;

        public IndexModel(RestaurantDbContext context)
        {
            _context = context;
        }

        public IList<Announcement> Announcements { get; set; }

        public async Task OnGetAsync()
        {
            Announcements = await _context.Announcements.ToListAsync();
        }
    }
}
