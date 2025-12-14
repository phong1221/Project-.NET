using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManagement.Data.Entities;
using StoreManagement.Services.Interfaces;

using StoreManagement.Web.Helpers;

namespace StoreManagement.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public ProductsController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index(string searchString, int? categoryId, decimal? minPrice, decimal? maxPrice, int? pageNumber)
        {
            // Populate Dropdowns
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();

            var products = await _productService.SearchProductsAsync(searchString, minPrice, maxPrice, categoryId);

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentCategory"] = categoryId;
            ViewData["CurrentMinPrice"] = minPrice;
            ViewData["CurrentMaxPrice"] = maxPrice;

            int pageSize = 10;
            return View(PaginatedList<Product>.Create(products, pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryId", "CategoryName");
            ViewBag.SupplierId = new SelectList(await _supplierService.GetAllSuppliersAsync(), "SupplierId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(product);
                TempData["Success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.SupplierId = new SelectList(await _supplierService.GetAllSuppliersAsync(), "SupplierId", "Name", product.SupplierId);
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.SupplierId = new SelectList(await _supplierService.GetAllSuppliersAsync(), "SupplierId", "Name", product.SupplierId);
            
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId) return NotFound();

            if (ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(product);
                TempData["Success"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
             ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.SupplierId = new SelectList(await _supplierService.GetAllSuppliersAsync(), "SupplierId", "Name", product.SupplierId);
            return View(product);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                TempData["Success"] = "Xóa sản phẩm thành công!";
            }
            catch (Exception)
            {
                TempData["Error"] = "Không thể xóa sản phẩm này (có thể đang được sử dụng trong đơn hàng/kho).";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
