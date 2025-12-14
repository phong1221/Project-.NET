using StoreManagement.Data.Entities;

namespace StoreManagement.Web.Models
{
    public class DashboardViewModel
    {
        public decimal RevenueToday { get; set; }
        public decimal RevenueMonth { get; set; }
        public int OrdersToday { get; set; }
        public int NewCustomersMonth { get; set; }
        public int LowStockItemsCount { get; set; }
        public List<Order> RecentOrders { get; set; } = new List<Order>();
    }
}
