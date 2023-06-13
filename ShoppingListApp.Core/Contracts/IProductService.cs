using ShoppingListApp.Core.Models.Category;
using ShoppingListApp.Core.Models.Products;
using ShoppingListApp.Core.Models.Products.Enums;
using System.Threading.Tasks;

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

        Task<bool> ProductExistsAsync(int id);

        Task<int> GetProductCategoryIdAsync(int productId);

        Task EditProductAsync(ProductFormModel model, int productId);

        Task<IEnumerable<ProductServiceModel>> GetUserProductsAsync(Guid userid);

        Task AddToListAsync(int productId, Guid userId);

        Task RemoveFromListAsync(int productId);
    }
}
