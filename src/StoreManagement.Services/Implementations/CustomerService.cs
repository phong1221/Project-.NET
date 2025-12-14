using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Entities;
using StoreManagement.Data.Repositories;
using StoreManagement.Services.Interfaces;

namespace StoreManagement.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            customer.CreatedAt = DateTime.Now;
            await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            // Fix: Fetch existing (tracked) entity first to avoid InvalidOperationException 
            // due to attaching a new instance with same Key.
            var existing = await _customerRepository.GetByIdAsync(customer.CustomerId);
            if (existing != null)
            {
                existing.Name = customer.Name;
                existing.Phone = customer.Phone;
                existing.Email = customer.Email;
                existing.Address = customer.Address;
                // If password change is supported here:
                if (!string.IsNullOrEmpty(customer.Password))
                {
                    existing.Password = customer.Password;
                }
                
                await _customerRepository.UpdateAsync(existing);
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Customer>> SearchCustomersAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await _customerRepository.GetAllAsync();

            return await _customerRepository.Query()
                .Where(c => c.Name.Contains(keyword) || (c.Phone != null && c.Phone.Contains(keyword)))
                .ToListAsync();
        }
    }
}
