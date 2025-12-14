using StoreManagement.Data.Entities;

namespace StoreManagement.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier?> GetSupplierByIdAsync(int id);
        Task<IEnumerable<Supplier>> SearchSuppliersAsync(string keyword);
        Task AddSupplierAsync(Supplier supplier);
        Task UpdateSupplierAsync(Supplier supplier);
        Task DeleteSupplierAsync(int id);
    }
}
