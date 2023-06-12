using ShoppingListApp.Core.Models.Category;
using ShoppingListApp.Core.Models.Products;
using ShoppingListApp.Core.Models.Products.Enums;

namespace ShoppingListApp.Core.Contracts
{
    public interface IProductService
    {
        Task<int> CreateAsync(ProductFormModel model);

        Task<ProductDetailsViewModel> ProductDetailsByIdAsync(int id);

        Task<ProductQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            ProductSorting sorting = ProductSorting.Newest,
            int currentPage = 1,
            int productsPerPage = 1);

        Task<IEnumerable<string>> AllGategoriesNamesAsync();
    }
}
