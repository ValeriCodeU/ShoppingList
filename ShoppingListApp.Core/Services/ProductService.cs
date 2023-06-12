using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Core.Contracts;
using ShoppingListApp.Core.Models.Products;
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

        public async Task<int> CreateAsync(ProductFormModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            return product.Id;
        }

        public async Task<ProductDetailsViewModel> ProductDetailsByIdAsync(int id)
        {
            return await repo.AllReadonly<Product>()
                .Where(p => p.Id == id && p.IsActive)
                .Select(p => new ProductDetailsViewModel()
                {
                    CategoryName = p.Category.Name,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    Customer = new Models.Customers.CustomerServiceModel()
                    {
                        FirstName = p.Customer.FirstName,
                        LastName = p.Customer.LastName,
                        PhoneNumber = p.Customer.PhoneNumber,
                        Email = p.Customer.Email,
                    }

                }).FirstAsync();
        }
    }
}
