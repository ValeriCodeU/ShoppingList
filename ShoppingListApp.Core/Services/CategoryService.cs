using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Core.Contracts;
using ShoppingListApp.Core.Models.Category;
using ShoppingListApp.Infrastructure.Data.Common;
using ShoppingListApp.Infrastructure.Data.Entities;

namespace ShoppingListApp.Core.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly IRepository repo;

        public CategoryService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<int> AddCategoryAsync(CategoryDetailsViewModel model)
        {
            var category = new Category()
            {
                Name = model.Name,
            };

            
            await repo.AddAsync(category);
            await repo.SaveChangesAsync();

            return category.Id;
        }

        public async Task<IEnumerable<CategoryDetailsViewModel>> AllCategoriesAsync()
        {
            return await repo.AllReadonly<Category>()
                .Where(c => c.IsActive)
                .OrderBy(c => c.Name)
                .Select(c => new CategoryDetailsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,

                }).ToListAsync();

        }

        public async Task<CategoryDetailsViewModel> CategoryDetailsByIdAsync(int id)
        {
            return await repo.AllReadonly<Category>()
                .Where(c => c.Id == id && c.IsActive)
                .Select(c => new CategoryDetailsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,

                }).FirstAsync();
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await repo.AllReadonly<Category>().AnyAsync(c => c.Id == id && c.IsActive);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await repo.GetByIdAsync<Category>(id);
            category.IsActive = false;
            await repo.SaveChangesAsync();

            return true;            
        }

        public async Task EditCategoryAsync(int categoryId, CategoryDetailsViewModel model)
        {
            var category = await repo.GetByIdAsync<Category>(categoryId);

            category.Name = model.Name;

            await repo.SaveChangesAsync();
        }

        
    }
}
