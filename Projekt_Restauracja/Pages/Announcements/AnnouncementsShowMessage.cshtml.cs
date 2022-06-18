using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Restauracja.Data;
using Projekt_Restauracja.Models;

namespace Projekt_Restauracja.Pages.Announcements
{
    public class AnnouncementShowMessage : PageModel
    {
        private RestaurantDbContext _context { get; set; }
        public IList<Announcement> Announcements { get; set; }
        public Announcement Announcement { get; set; }


        public AnnouncementShowMessage(RestaurantDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            if (Announcements != null)
                _context.Announcements.Add(Announcement);
            Announcements = _context.Announcements.ToList();

        }
    }
}
