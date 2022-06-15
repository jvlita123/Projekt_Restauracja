using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Restauracja
{
    public class CategoryGroup
    {
        public int DishId { get; set; } //klucz obcy do Person
        public virtual Dish Dish { get; set; }
        public int CategoryId { get; set; } //klucz obcy do Group
        public virtual Category Category { get; set; }



    }
}
