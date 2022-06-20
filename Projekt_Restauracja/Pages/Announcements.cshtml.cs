using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Projekt_Restauracja.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Restauracja.Pages
{
    public class Announcements : PageModel
    {
        private readonly IAnnouncementsService _announcementsService;
        public IQueryable<Announcement> Records { get; set; }

        public Announcements(IAnnouncementsService announcementsService)
        {

            _announcementsService = announcementsService;
        }
        public void OnGet()
        {

            Records = _announcementsService.GetAnnouncements();
        }
    }

     

    
}
