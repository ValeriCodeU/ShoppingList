using ShoppingListApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Core.Contracts
{
    public interface IProductService
    {
        Task<int> CreateAsync(ProductFormModel model);
    }
}
