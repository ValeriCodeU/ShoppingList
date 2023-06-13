﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Core.Constants;
using ShoppingListApp.Core.Contracts;
using ShoppingListApp.Core.Models.Products;
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

            //var result = await productService.AllAsync(
            //    query.Category,
            //    query.SearchTerm,
            //    query.Sorting,
            //    query.CurrentPage,
            //    AllProductsQueryModel.ProductPerPage);

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
                return RedirectToAction(nameof(All));
            }


            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.EditProductAsync(model, id);

            return RedirectToAction(nameof(Details), new { id });
        }


        public async Task<IActionResult> ListProducts()
        {
            //IEnumerable<ProductServiceModel> model;

            return View();
        }
    }
}
