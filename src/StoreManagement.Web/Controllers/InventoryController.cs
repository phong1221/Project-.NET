using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreManagement.Data.Entities;
using StoreManagement.Services.Interfaces;
using StoreManagement.Web.Helpers;

namespace StoreManagement.Web.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _service;
        private readonly IProductService _productService;

        public InventoryController(IInventoryService service, IProductService productService)
        {
            _service = service;
            _productService = productService;
        }

        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;
            var data = await _service.SearchInventoriesAsync(searchString);
            int pageSize = 10;
            return View(PaginatedList<Inventory>.Create(data, pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ProductId = new SelectList(await _productService.GetAllProductsAsync(), "ProductId", "ProductName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                await _service.AddInventoryAsync(inventory);
                return RedirectToAction(nameof(Index));
            }
             ViewBag.ProductId = new SelectList(await _productService.GetAllProductsAsync(), "ProductId", "ProductName", inventory.ProductId);
            return View(inventory);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var inventory = await _service.GetInventoryByIdAsync(id);
            if (inventory == null) return NotFound();
            ViewBag.ProductId = new SelectList(await _productService.GetAllProductsAsync(), "ProductId", "ProductName", inventory.ProductId);
            return View(inventory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Inventory inventory)
        {
            if (id != inventory.InventoryId) return NotFound();

            if (ModelState.IsValid)
            {
                await _service.UpdateInventoryAsync(inventory);
                return RedirectToAction(nameof(Index));
            }
             ViewBag.ProductId = new SelectList(await _productService.GetAllProductsAsync(), "ProductId", "ProductName", inventory.ProductId);
            return View(inventory);
        }

         public async Task<IActionResult> Delete(int id)
        {
            var inventory = await _service.GetInventoryByIdAsync(id);
            if (inventory == null) return NotFound();
            return View(inventory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteInventoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
