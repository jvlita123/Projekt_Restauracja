using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Projekt_Restauracja
{
    public interface IAnnouncementsService
    {
        public IQueryable<Announcement> GetAnnouncements();
        public IQueryable<Announcement> AddAnnouncements(string description, string NameOfAnnouncement);

    }
}
