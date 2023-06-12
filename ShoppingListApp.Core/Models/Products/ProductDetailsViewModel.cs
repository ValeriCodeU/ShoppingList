using ShoppingListApp.Core.Models.Customers;

namespace ShoppingListApp.Core.Models.Products
{
    public class ProductDetailsViewModel : ProductServiceModel
    {
        public string Description { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public CustomerServiceModel? Customer { get; set; }
    }
}
