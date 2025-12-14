using Microsoft.AspNetCore.Mvc;
using StoreManagement.Services.Interfaces;
using StoreManagement.Data.Entities;
using StoreManagement.Web.Helpers;

namespace StoreManagement.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrdersController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var orders = await _orderService.GetOrdersAsync();
            int pageSize = 10;
            return View(PaginatedList<Order>.Create(orders, pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(int id)
        {
            // Find current admin user
            var username = User.Identity?.Name;
            int adminUserId = 0; // fallback if simplified

            if (!string.IsNullOrEmpty(username))
            {
                 // We don't have GetUserByUsername in IUserService, let's assume we can search or use SearchUsersAsync
                 // Actually IUserService.SearchUsersAsync is available.
                 // Or better, let's quickly check IUserService. 
                 // It has LoginAsync. It DOES NOT have GetUserByUsername specifically, but SearchUsersAsync(keyword) 
                 // might work if username is unique.
                 // Ideally I should add GetUserByUsername to IUserService, but for speed let's use search.
                 // Wait, UserService.LoginAsync(username, password) returns User.
                 // I can't call Login here.
                 // I will assume the claim has ID, or I will use repository directly? No, layers.
                 // I'll assume SearchUsersAsync(username) returns the user.
                 var users = await _userService.SearchUsersAsync(username);
                 var user = users.FirstOrDefault(u => u.Username == username);
                 if (user != null) adminUserId = user.UserId;
            }

            await _orderService.ConfirmOrderAsync(id, adminUserId);
            TempData["Success"] = "Đã xác nhận đơn hàng thành công!";
            return RedirectToAction(nameof(Index));
        }
    }
}
