using Microsoft.AspNetCore.Identity;
using Projekt_Restauracja.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Restauracja
{
    public class User : IdentityUser
    {

        public int Id { get; set; }
        public string email { get; set; }
       
        [Display(Name = "Twój rok urodzenia")]
        [Column(TypeName = "varchar(100)")]
        public int? Year { get; set; }

        public string Name { get; set; }

        [Display(Name = "Twoje nazwisko (opcjonalne)")]
        [Column(TypeName = "varchar(100)")]
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfrimPassword { get; set; }
    //    public int RoleId { get; set; }

    //    public virtual IdentityRole Role { get; set; }
        public string PasswordHash { get; set; }

        [Display(Name = "Zdjêcia")]
        public virtual ICollection<Image>? Images { get; set; }


    }
}
