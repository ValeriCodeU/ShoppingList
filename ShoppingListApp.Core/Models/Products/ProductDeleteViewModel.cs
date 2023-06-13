using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Core.Models.Products
{
    public class ProductDeleteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
