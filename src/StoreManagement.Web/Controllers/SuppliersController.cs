using Microsoft.AspNetCore.Mvc;
using StoreManagement.Data.Entities;
using StoreManagement.Services.Interfaces;
using StoreManagement.Web.Helpers;

namespace StoreManagement.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _service;

        public SuppliersController(ISupplierService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;
            var data = await _service.SearchSuppliersAsync(searchString);
            int pageSize = 10;
            return View(PaginatedList<Supplier>.Create(data, pageNumber ?? 1, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _service.AddSupplierAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _service.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Supplier supplier)
        {
            if (id != supplier.SupplierId) return NotFound();

            if (ModelState.IsValid)
            {
                await _service.UpdateSupplierAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

         public async Task<IActionResult> Delete(int id)
        {
             var supplier = await _service.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteSupplierAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
