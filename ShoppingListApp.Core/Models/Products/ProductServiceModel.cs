using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingListApp.Core.Models.Products
{
    public class ProductServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Display(Name = "Image URL")]

        public string? ImageUrl { get; set; }

        [Display(Name = "Product Price")]

        public decimal Price { get; set; }

        [Display(Name = "Is Saled")]

        public bool IsSaled { get; set; }
    }
}
