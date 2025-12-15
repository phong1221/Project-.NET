using Microsoft.AspNetCore.Mvc;
using StoreManagement.Data.Entities;
using StoreManagement.Services.Interfaces;
using StoreManagement.Web.Helpers;

namespace StoreManagement.Web.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly IPromotionService _service;

        public PromotionsController(IPromotionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;
            var data = await _service.SearchPromotionsAsync(searchString);
             int pageSize = 10;
            return View(PaginatedList<Promotion>.Create(data, pageNumber ?? 1, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                await _service.AddPromotionAsync(promotion);
                TempData["Success"] = "Thêm khuyến mãi thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(promotion);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var promotion = await _service.GetPromotionByIdAsync(id);
            if (promotion == null) return NotFound();
            return View(promotion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Promotion promotion)
        {
            if (id != promotion.PromoId) return NotFound();

            if (ModelState.IsValid)
            {
                await _service.UpdatePromotionAsync(promotion);
                TempData["Success"] = "Cập nhật khuyến mãi thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(promotion);
        }

        public async Task<IActionResult> Delete(int id)
        {
             var promotion = await _service.GetPromotionByIdAsync(id);
            if (promotion == null) return NotFound();
            return View(promotion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeletePromotionAsync(id);
            TempData["Success"] = "Xóa khuyến mãi thành công!";
            return RedirectToAction(nameof(Index));
        }
    }
}
