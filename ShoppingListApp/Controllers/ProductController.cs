using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Core.Constants;
using ShoppingListApp.Core.Contracts;
using ShoppingListApp.Core.Models.Products;
using ShoppingListApp.Extensions;
using static ShoppingListApp.Core.Constants.UserRoleConstants;

namespace ShoppingListApp.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public ProductController(
            ICategoryService _categoryService,
            IProductService _productService)
        {
            categoryService = _categoryService;
            productService = _productService;
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]

        public async Task<IActionResult> Add()
        {
            var model = new ProductFormModel()
            {
                Categories = await categoryService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]

        public async Task<IActionResult> Add(ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await categoryService.CategoryExistsAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.AllCategoriesAsync();

                return View(model);
            }

            var id = await productService.CreateAsync(model);

            if (id != 0)
            {
                TempData[MessageConstants.SuccessMessage] = "You have successfully added a product";
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var product = await productService.ProductDetailsByIdAsync(id);

            return View(product);
        }

        public async Task<IActionResult> All([FromQuery] AllProductsQueryModel query)
        {
            var productsPerPage = AllProductsQueryModel.ProductPerPage;
            var result = await productService
                .AllAsync(              
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                productsPerPage);

            query.TotalProductsCount = result.TotalProductsCount;
            query.Products = result.Products;

            query.Categories = await productService.AllGategoriesNamesAsync();

            return View(query);
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]

        public async Task<IActionResult> Edit(int id)
        {

            if (!await productService.ProductExistsAsync(id))
            {
                TempData[MessageConstants.ErrorMessage] = "This product doest not exists!";
                return RedirectToAction(nameof(All));
            }

            var model = new ProductFormModel();

            var product = await productService.ProductDetailsByIdAsync(id);
            var productCategoryId = await productService.GetProductCategoryIdAsync(product.Id);

            model.Name = product.Name;
            model.Price = product.Price;
            model.ImageUrl = product.ImageUrl;
            model.Description = product.Description;
            model.CategoryId = productCategoryId;
            model.Categories = await categoryService.AllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]

        public async Task<IActionResult> Edit(ProductFormModel model, int id)
        {
            if (!await productService.ProductExistsAsync(id))
            {
                TempData[MessageConstants.ErrorMessage] = "This product doest not exists!";
                model.Categories = await categoryService.AllCategoriesAsync();
                return RedirectToAction(nameof(All));
            }

            if (!await categoryService.CategoryExistsAsync(model.CategoryId))
            {
                TempData[MessageConstants.ErrorMessage] = "Category does not exist!";
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.AllCategoriesAsync();
                return View(model);
            }

            await productService.EditProductAsync(model, id);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]

        public async Task<IActionResult> ListProducts()
        {
            var model = await productService.GetUserProductsAsync(User.Id());

            return View(model);
        }

        public async Task<IActionResult> AddProductToCollection(int id)
        {
            await productService.AddToListAsync(id, User.Id());

            TempData[MessageConstants.SuccessMessage] = "You have successfully added this product to your shopping list!";            

            return RedirectToAction(nameof(ListProducts));
        }

        public async Task<IActionResult> RemoveProductFromCollection(int id)
        {

            if (!await productService.IsOwnerAsync(User.Id(), id)) 
            {
                TempData[MessageConstants.ErrorMessage] = "You cannot access this service!";
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await productService.RemoveFromListAsync(id);

            TempData[MessageConstants.SuccessMessage] = "You have successfully removed this product from your shopping list";

            return RedirectToAction(nameof(ListProducts));
        }

        [HttpPost]

        public async Task<IActionResult> MarkSold(int id)
        {
            var userId = User.Id();

            await productService.MarkProductAsSold(id, userId);

            TempData[MessageConstants.SuccessMessage] = "You have successfully added this product as purchased";

            return RedirectToAction(nameof(ListProducts));
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            if (!await productService.ProductExistsAsync(id))
            {
                TempData[MessageConstants.ErrorMessage] = "This product doest not exists!";
                return RedirectToAction(nameof(All));
            }

            var product = await productService.ProductDetailsByIdAsync(id);

            var model = new ProductDeleteViewModel()
            {
                Name = product.Name,
                Id = product.Id

            };

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(ProductDeleteViewModel model)
        {
            if (!await productService.ProductExistsAsync(model.Id))
            {
                TempData[MessageConstants.ErrorMessage] = "This product doest not exists!";
                return RedirectToAction(nameof(All));
            }

            var result = await productService.DeleteProductAsync(model.Id);

            if (result)
            {
                TempData[MessageConstants.SuccessMessage] = "This product has been successfully deleted!";
            }

            return RedirectToAction(nameof(All));
        }
    }
}
