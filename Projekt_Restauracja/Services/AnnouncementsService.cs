using Projekt_Restauracja.Data;
using System.Collections.Generic;
using System.Linq;

namespace Projekt_Restauracja.Services
{

    public class AnnouncementsService : IAnnouncementsService
    {
        private readonly RestaurantDbContext _restaurantDbContext;
          IList<Announcement> Announcements { get; set; }
        public AnnouncementsService(RestaurantDbContext restaurantContext)
        {
            _restaurantDbContext = restaurantContext;
        }
        public IQueryable<Announcement> GetAnnouncements()
        {
            return _restaurantDbContext.Announcements;

        }
        public IQueryable<Announcement> AddAnnouncements(string description, string NameOfAnnouncement)
        {
            Announcement announcement = new Announcement();
            announcement.Description = description;
            announcement.NameOfAnnouncement = NameOfAnnouncement;
            _restaurantDbContext.Announcements.Add(announcement);
            _restaurantDbContext.SaveChanges();
            return _restaurantDbContext.Announcements;
        }

     
    }
}

