using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Restauracja
{
    public class Dish
    {

        public int Id { get; set; } 

        //[Required(ErrorMessage = "Pole jest obowi¹zkowe")]
        [MaxLength(100)]
        [Display(Name = "Nazwa")]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

       // [Required(ErrorMessage = "Pole jest obowi¹zkowe")]
        [Display(Name = "Cena")]
        [Column(TypeName = "decimal")]

        public decimal Price { get; set; }

        //[Required(ErrorMessage = "Pole jest obowi¹zkowe")]
        [MinLength(30)]
        [MaxLength(1000)]
        [Display(Name = "Opis dania")]
        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }
        public string ImgPath { get; set; }

        public ICollection<CategoryGroup>? categoryGroups { get; set; }


    }
}
