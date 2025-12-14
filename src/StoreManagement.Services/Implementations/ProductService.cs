using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Entities;
using StoreManagement.Data.Repositories;
using StoreManagement.Services.Interfaces;

namespace StoreManagement.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.Query()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.Query()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task AddProductAsync(Product product)
        {
            product.CreatedAt = DateTime.Now;
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword, decimal? minPrice, decimal? maxPrice, int? categoryId)
        {
            var query = _productRepository.Query()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(p => p.ProductName.Contains(keyword) || (p.Barcode != null && p.Barcode.Contains(keyword)));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            return await query.ToListAsync();
        }
    }
}
