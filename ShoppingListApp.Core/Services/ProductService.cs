using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Core.Contracts;
using ShoppingListApp.Core.Models.Category;
using ShoppingListApp.Core.Models.Products;
using ShoppingListApp.Core.Models.Products.Enums;
using ShoppingListApp.Infrastructure.Data.Common;
using ShoppingListApp.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddToListAsync(int productId, Guid userId)
        {
            var product = await repo.GetByIdAsync<Product>(productId);

            product.CustomerId = userId;

            await repo.SaveChangesAsync();
        }

        public async Task<ProductQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, ProductSorting sorting = ProductSorting.Newest, int currentPage = 1, int productsPerPage = 1)
        {
            var result = new ProductQueryServiceModel();

            var products = repo.AllReadonly<Product>().Where(p => p.IsActive && p.CustomerId == null);

            if (!String.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.Name == category);
            }

            if (!String.IsNullOrEmpty(searchTerm))
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                products = products
                    .Where(p => EF.Functions.Like(p.Name.ToLower(), searchTerm) ||
                        EF.Functions.Like(p.Description.ToLower(), searchTerm)); 
            }

            products = sorting switch
            {
                ProductSorting.Price => products.OrderBy(p => p.Price),                
                ProductSorting.Newest => products.OrderBy(p => p.Id),
                _ => products.OrderByDescending(p => p.Id)
            };

            var productList = await products.Skip((currentPage - 1) * productsPerPage).Take(productsPerPage)
                .Select(p => new ProductServiceModel()                
                {
                    Id = p.Id,
                    Name = p.Name,                    
                    ImageUrl = p.ImageUrl,
                    IsSold = p.CustomerId != null,
                    Price = p.Price
                }).ToListAsync();

            var totalProducts = await products.CountAsync();

            result.TotalProductsCount = totalProducts;
            result.Products = productList;

            return result;
        }

        public async Task<IEnumerable<string>> AllGategoriesNamesAsync()
        {
            return await repo.AllReadonly<Category>().Select(c => c.Name).Distinct().ToListAsync();
        }

        public async Task<int> CreateAsync(ProductFormModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            return product.Id;
        }

        public async Task EditProductAsync(ProductFormModel model, int productId)
        {
            var product = await repo.GetByIdAsync<Product>(productId);

            if (product.IsActive)
            {
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;
                product.ImageUrl = model.ImageUrl;
                product.Description = model.Description;

                await repo.SaveChangesAsync();
            }
        }

        public async Task<int> GetProductCategoryIdAsync(int productId)
        {
            return (await repo.GetByIdAsync<Product>(productId)).CategoryId;
        }

        public async Task<IEnumerable<ProductServiceModel>> GetUserProductsAsync(Guid userid)
        {
            return await repo.AllReadonly<Product>()
                .Where(p => p.CustomerId == userid).
                Select(p => new ProductServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    IsSold = p.CustomerId != null
                }).ToListAsync();
        }

        public async Task<ProductDetailsViewModel> ProductDetailsByIdAsync(int id)
        {
            return await repo.AllReadonly<Product>()
                .Where(p => p.Id == id && p.IsActive)
                .Select(p => new ProductDetailsViewModel()
                {
                    Id = p.Id,
                    CategoryName = p.Category.Name,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Description = p.Description,
                    IsSold = p.CustomerId != null,
                    Customer = new Models.Customers.CustomerServiceModel()
                    {
                        FirstName = p.Customer.FirstName,
                        LastName = p.Customer.LastName,
                        PhoneNumber = p.Customer.PhoneNumber,
                        Email = p.Customer.Email,
                    }

                }).FirstAsync();
        }

        public async Task<bool> ProductExistsAsync(int id)
        {
            return await repo.AllReadonly<Product>().AnyAsync(p => p.Id == id && p.IsActive);
        }

        public async Task RemoveFromListAsync(int productId)
        {
            var product = await repo.GetByIdAsync<Product>(productId);

            product.CustomerId = null;

            await repo.SaveChangesAsync();
        }
    }
}
