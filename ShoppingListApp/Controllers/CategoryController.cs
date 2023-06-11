using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Core.Constants;
using ShoppingListApp.Core.Contracts;
using ShoppingListApp.Core.Models.Category;

namespace ShoppingListApp.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }


        public async Task<IActionResult> All()
        {

            var model = await categoryService.AllCategoriesAsync();

            return View(model);
        }

        [HttpGet]

        public IActionResult Add()
        {
            var model = new CategoryDetailsViewModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Add(CategoryDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.AddCategoryAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {


            if (!await categoryService.CategoryExistsAsync(id))
            {
                TempData[MessageConstants.ErrorMessage] = "Category does not exist!";
                return RedirectToAction(nameof(All));
            }

            var model = new CategoryDetailsViewModel();

            var category = await categoryService.CategoryDetailsByIdAsync(id);

            model.Name = category.Name;

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(CategoryDetailsViewModel model, int id)
        {
            if (!await categoryService.CategoryExistsAsync(id))
            {
                TempData[MessageConstants.ErrorMessage] = "Category does not exist!";

                return RedirectToAction("Index", "Home");
            }

            await categoryService.EditCategoryAsync(id, model);

            TempData[MessageConstants.SuccessMessage] = "You successfully edited this category!";

            return RedirectToAction(nameof(All));
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            if (!await categoryService.CategoryExistsAsync(id))
            {
                TempData[MessageConstants.ErrorMessage] = "Category does not exist!";

                return RedirectToAction("Index", "Home");
            }

            var model = new CategoryDetailsViewModel();

            var category = await categoryService.CategoryDetailsByIdAsync(id);

            model.Name = category.Name;

            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(CategoryDetailsViewModel model)
        {
            if (!await categoryService.CategoryExistsAsync(model.Id))
            {
                TempData[MessageConstants.ErrorMessage] = "Category does not exist!";

                return RedirectToAction("Index", "Home");
            }

            var result = await categoryService.DeleteCategoryAsync(model.Id);

            if (result)
            {
                TempData[MessageConstants.SuccessMessage] = "You successfully deleted this category!";
            }

            return RedirectToAction(nameof(All));
        }

    }
}
