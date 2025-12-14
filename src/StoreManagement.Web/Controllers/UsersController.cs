using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.Data.Entities;
using StoreManagement.Services.Interfaces;

using StoreManagement.Web.Helpers;

namespace StoreManagement.Web.Controllers
{
    // [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;
            var users = await _service.SearchUsersAsync(searchString);
            
            // Convert to IQueryable for efficiency if possible in Service, 
            // but since Service returns IEnumerable, we paginate in memory for now OR update Service.
            // For optimal performance, Services should return IQueryable, but for "simplistic" layered arch aimed at CRUD,
            // we will paginate correctly using the Helper on the result.
            
            int pageSize = 10;
            return View(PaginatedList<User>.Create(users, pageNumber ?? 1, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Simple check for dupe username
                var existing = (await _service.SearchUsersAsync(user.Username)).FirstOrDefault(u => u.Username == user.Username);
                if (existing != null)
                {
                    ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại");
                    return View(user);
                }

                await _service.AddUserAsync(user);
                TempData["Success"] = "Thêm nhân viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.UserId) return NotFound();

            if (ModelState.IsValid)
            {
                await _service.UpdateUserAsync(user);
                TempData["Success"] = "Cập nhật nhân viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try 
            {
                await _service.DeleteUserAsync(id);
                TempData["Success"] = "Xóa nhân viên thành công!";
            }
            catch
            {
                TempData["Error"] = "Không thể xóa nhân viên này.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
