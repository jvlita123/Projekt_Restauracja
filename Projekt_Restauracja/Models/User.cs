using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Restauracja
{
    public class User
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string email { get; set; }


        [Display(Name = "Twój rok urodzenia")]
        [Required(ErrorMessage = "uzupe³nij dane"), Range(1899, 2022, ErrorMessage = "Oczekiwana wartoœæ {0} z zakresu {1} i {2}.")]
        [Column(TypeName = "varchar(100)")]
        public int? Year { get; set; }

        [MaxLength(100)]
        [Display(Name = "Twoje nazwisko (opcjonalne)")]
        [Column(TypeName = "varchar(100)")]

        public string? Surname { get; set; }


        public bool IsAdmin()
        {

            if (!this.email.StartsWith("Admin@"))
            {
                return false;
            }
            return true;
        }

    }
}
