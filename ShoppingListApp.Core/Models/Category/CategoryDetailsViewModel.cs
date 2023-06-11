using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Core.Models.Category
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
