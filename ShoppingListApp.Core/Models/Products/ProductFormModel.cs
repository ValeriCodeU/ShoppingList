using ShoppingListApp.Core.Models.Category;
using System.ComponentModel.DataAnnotations;
using static ShoppingListApp.Core.Constants.ViewModelConstants.Product;

namespace ShoppingListApp.Core.Models.Products
{
    public class ProductFormModel
    {
        [Required]
        [StringLength(MaxProductName, MinimumLength = MinProductName)]

        public string Name { get; set; } = null!;
        
        [Required]
        [StringLength(MaxProductDescription, MinimumLength = MinProductDescription)]

        public string Description { get; set; } = null!;

        [Display(Name = "Image URL")]
        [StringLength(MaxProductImageUrl)]

        public string? ImageUrl { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        [Range(typeof(decimal), MinProductPrice, MaxProductPrice,
            ErrorMessage = "Product Price must be a positive number and less than {2} leva.")]

        public decimal Price { get; set; }

        [Display(Name = "Category")]

        public int CategoryId { get; set; }

        public IEnumerable<CategoryDetailsViewModel> Categories { get; set; } = new List<CategoryDetailsViewModel>();
    }
}
