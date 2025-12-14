using StoreManagement.Data.Entities;

namespace StoreManagement.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int? userId, int? customerId, int? promoId, List<(int productId, int quantity)> items, string paymentMethod, string status = "paid");
        Task ConfirmOrderAsync(int orderId, int adminUserId);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
    }
}
