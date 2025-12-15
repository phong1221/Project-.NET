using Microsoft.AspNetCore.Mvc;
using StoreManagement.Data.Entities;
using StoreManagement.Services.Interfaces;
using StoreManagement.Web.Helpers;

namespace StoreManagement.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;
            var data = await _service.SearchCategoriesAsync(searchString);
            int pageSize = 10;
            return View(PaginatedList<Category>.Create(data, pageNumber ?? 1, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCategoryAsync(category);
                TempData["Success"] = "Thêm danh mục thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _service.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.CategoryId) return NotFound();

            if (ModelState.IsValid)
            {
                await _service.UpdateCategoryAsync(category);
                TempData["Success"] = "Cập nhật danh mục thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
             var category = await _service.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteCategoryAsync(id);
            TempData["Success"] = "Xóa danh mục thành công!";
            return RedirectToAction(nameof(Index));
        }
    }
}
