using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data;

namespace StoreManagement.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly StoreManagementContext _context;

        public ReportsController(StoreManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // 1. Revenue Stats (Cards)
            var today = DateTime.Today;
            var monthStart = new DateTime(today.Year, today.Month, 1);
            
            ViewBag.RevenueToday = await _context.Payments
                .Where(p => p.PaymentDate >= today).SumAsync(p => p.Amount);
            ViewBag.RevenueMonth = await _context.Payments
                .Where(p => p.PaymentDate >= monthStart).SumAsync(p => p.Amount);
            ViewBag.RevenueYear = await _context.Payments
                .Where(p => p.PaymentDate.Year == today.Year).SumAsync(p => p.Amount);

            // 2. Chart: Revenue Last 7 Days
            var sevenDaysAgo = today.AddDays(-6);
            var revenueData = await _context.Payments
                .Where(p => p.PaymentDate >= sevenDaysAgo)
                .GroupBy(p => p.PaymentDate.Date)
                .Select(g => new { Date = g.Key, Total = g.Sum(p => p.Amount) })
                .ToListAsync();
            
            // Fill gaps
            var labels = new List<string>();
            var values = new List<decimal>();
            for (int i = 0; i < 7; i++)
            {
                var date = sevenDaysAgo.AddDays(i);
                labels.Add(date.ToString("dd/MM"));
                var record = revenueData.FirstOrDefault(r => r.Date == date);
                values.Add(record?.Total ?? 0);
            }
            
            ViewBag.ChartLabels = labels;
            ViewBag.ChartValues = values;

            // 3. Chart: Top 5 Products
            var topProducts = await _context.OrderItems
                .Include(oi => oi.Product)
                .GroupBy(oi => oi.ProductId)
                .Select(g => new 
                { 
                    Name = g.First().Product.ProductName, 
                    Qty = g.Sum(oi => oi.Quantity) 
                })
                .OrderByDescending(x => x.Qty)
                .Take(5)
                .ToListAsync();

            ViewBag.TopProdLabels = topProducts.Select(x => x.Name).ToList();
            ViewBag.TopProdValues = topProducts.Select(x => x.Qty).ToList();

            // 4. Chart: Payment Methods
            var methods = await _context.Payments
                .GroupBy(p => p.PaymentMethod)
                .Select(g => new { Method = g.Key, Count = g.Count() })
                .ToListAsync();
            
            ViewBag.MethodLabels = methods.Select(x => x.Method).ToList();
            ViewBag.MethodValues = methods.Select(x => x.Count).ToList();

            return View();
        }
    }
}
