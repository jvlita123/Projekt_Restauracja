using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Restauracja
{
    public class Announcement
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Display(Name = "Nazwa ogłoszenia")]
        [Column(TypeName = "varchar(100)")]
        public string NameOfAnnouncement { get; set; }

        [MinLength(30)]
        [MaxLength(1000)]
        [Display(Name = "Treść ogłoszenia")]
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }

    }
}
