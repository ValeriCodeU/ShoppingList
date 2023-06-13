using ShoppingListApp.Core.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDetailsViewModel>> AllCategoriesAsync();

        Task AddCategoryAsync(CategoryDetailsViewModel model);

        Task EditCategoryAsync(int categoryId, CategoryDetailsViewModel model);

        Task<bool> CategoryExistsAsync(int id);

        Task<CategoryDetailsViewModel> CategoryDetailsByIdAsync(int id);

        Task<bool> DeleteCategoryAsync(int id);        
    }
}
