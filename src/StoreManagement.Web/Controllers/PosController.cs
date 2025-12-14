using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.Services.Interfaces;
using StoreManagement.Web.Models;
using System.Security.Claims;

namespace StoreManagement.Web.Controllers
{
    [Authorize]
    public class PosController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;

        public PosController(IProductService productService, ICustomerService customerService, ICategoryService categoryService, IOrderService orderService)
        {
            _productService = productService;
            _customerService = customerService;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new PosViewModel
            {
                Products = await _productService.GetAllProductsAsync(),
                Customers = await _customerService.GetAllCustomersAsync(),
                Categories = await _categoryService.GetAllCategoriesAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("UserId")?.Value ?? "1"); // Default to 1 if testing
                var items = request.Items.Select(i => (i.ProductId, i.Quantity)).ToList();

                var order = await _orderService.CreateOrderAsync(userId, request.CustomerId, null, items, request.PaymentMethod);
                
                return Json(new { success = true, orderId = order.OrderId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
