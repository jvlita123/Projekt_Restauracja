using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Projekt_Restauracja
{
    public interface IDishService
    {
        public IQueryable<Dish> GetDishes();
        public IQueryable<Category> AddCategory();

    }
}
