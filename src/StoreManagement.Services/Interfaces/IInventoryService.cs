using StoreManagement.Data.Entities;

namespace StoreManagement.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
        Task<Inventory?> GetInventoryByIdAsync(int id);
        Task<IEnumerable<Inventory>> SearchInventoriesAsync(string keyword);
        Task AddInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory);
        Task DeleteInventoryAsync(int id);
        Task<Inventory?> GetInventoryByProductIdAsync(int productId);
    }
}
