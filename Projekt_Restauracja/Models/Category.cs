using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Restauracja
{
    public class Category
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryGroup>? CategoryGroups { get; set; }

        

    }
}
