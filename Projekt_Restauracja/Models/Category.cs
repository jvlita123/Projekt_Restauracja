using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Restauracja
{
    public class Category
    {

        public int Id { get; set; }
        [Display(Name = "Kategoria")]

        public string Name { get; set; }

        public virtual ICollection<CategoryGroup>? CategoryGroups { get; set; } 
        public virtual ICollection<Dish> Dishes { get; set; } 



    }
}
