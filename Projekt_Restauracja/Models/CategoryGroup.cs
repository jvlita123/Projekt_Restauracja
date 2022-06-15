using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Restauracja
{
    public class CategoryGroup
    {

        public int Id { get; set; }
        public int DishId { get; set; } //klucz obcy do Dish
        public Dish Dish  { get; set; }
        public int CategoryId { get; set; } //klucz obcy do Category
        public Category Category { get; set; }


    }
}
