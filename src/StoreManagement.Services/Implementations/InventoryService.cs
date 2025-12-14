using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Entities;
using StoreManagement.Data.Repositories;
using StoreManagement.Services.Interfaces;

namespace StoreManagement.Services.Implementations
{
    public class InventoryService : IInventoryService
    {
        private readonly IRepository<Inventory> _repository;

        public InventoryService(IRepository<Inventory> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
        {
            return await _repository.Query()
                .Include(i => i.Product)
                .ToListAsync();
        }

        public async Task<Inventory?> GetInventoryByIdAsync(int id)
        {
             return await _repository.Query()
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.InventoryId == id);
        }

        public async Task<IEnumerable<Inventory>> SearchInventoriesAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllInventoriesAsync();

            return await _repository.Query()
                .Include(i => i.Product)
                .Where(i => i.Product.ProductName.Contains(keyword))
                .ToListAsync();
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            inventory.UpdatedAt = DateTime.Now;
            await _repository.AddAsync(inventory);
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            inventory.UpdatedAt = DateTime.Now;
            await _repository.UpdateAsync(inventory);
        }

        public async Task DeleteInventoryAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
