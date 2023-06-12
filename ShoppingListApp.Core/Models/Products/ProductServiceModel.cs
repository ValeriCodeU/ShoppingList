using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Core.Models.Products
{
    public class ProductServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;       

        [Display(Name = "Image URL")]

        public string? ImageUrl { get; set; }

        [Display(Name = "Product Price")]

        public decimal Price { get; set; }

        [Display(Name = "Is Saled")]

        public bool IsSold { get; set; }
    }
}
