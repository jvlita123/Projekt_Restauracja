using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Restauracja
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
