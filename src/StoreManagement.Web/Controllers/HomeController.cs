using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data;
using StoreManagement.Web.Models;

namespace StoreManagement.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StoreManagementContext _context;

    public HomeController(ILogger<HomeController> logger, StoreManagementContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var today = DateTime.Today;
        var monthStart = new DateTime(today.Year, today.Month, 1);

        var model = new DashboardViewModel
        {
            RevenueToday = await _context.Payments
                .Where(p => p.PaymentDate >= today)
                .SumAsync(p => p.Amount),

            RevenueMonth = await _context.Payments
                .Where(p => p.PaymentDate >= monthStart)
                .SumAsync(p => p.Amount),

            OrdersToday = await _context.Orders
                .Where(o => o.OrderDate >= today)
                .CountAsync(),

            NewCustomersMonth = await _context.Customers
                .Where(c => c.CreatedAt >= monthStart)
                .CountAsync(),

            LowStockItemsCount = await _context.Inventories
                .Where(i => i.Quantity < 10)
                .CountAsync(),

            RecentOrders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.User)
                .OrderByDescending(o => o.OrderDate)
                .Take(5)
                .ToListAsync()
        };

        return View(model);
    }

    public IActionResult Store()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
