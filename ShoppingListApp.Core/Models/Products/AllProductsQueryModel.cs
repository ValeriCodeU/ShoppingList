using ShoppingListApp.Core.Models.Products.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Core.Models.Products
{
    public class AllProductsQueryModel
    {
        public const int ProductPerPage = 3;

        public string? Category { get; set; }

        [Display(Name = "Search by text")]

        public string? SearchTerm { get; set; }

        public ProductSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalProductsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<ProductServiceModel> Products { get; set; } = new List<ProductServiceModel>();
    }
}
