using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Entities;
using StoreManagement.Data.Repositories;
using StoreManagement.Services.Interfaces;

namespace StoreManagement.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<Supplier> _repository;

        public SupplierService(IRepository<Supplier> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _repository.GetAllAsync();
        }

         public async Task<Supplier?> GetSupplierByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Supplier>> SearchSuppliersAsync(string keyword)
        {
             if (string.IsNullOrWhiteSpace(keyword))
                return await _repository.GetAllAsync();

            return await _repository.Query()
                .Where(s => s.Name.Contains(keyword) || (s.Phone != null && s.Phone.Contains(keyword)))
                .ToListAsync();
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
             await _repository.AddAsync(supplier);
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
             await _repository.UpdateAsync(supplier);
        }

        public async Task DeleteSupplierAsync(int id)
        {
             await _repository.DeleteAsync(id);
        }
    }
}
