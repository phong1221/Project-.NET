using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Entities;
using StoreManagement.Data.Repositories;

namespace StoreManagement.Web.Services
{
    public class CartService
    {
        private readonly CustomerAuthService _authService;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<OrderItem> _orderItemRepo;
        private readonly IRepository<Product> _productRepo;

        public List<CartItem> Items { get; private set; } = new List<CartItem>();
        public event Action OnChange;

        public CartService(CustomerAuthService authService, 
                           IRepository<Order> orderRepo, 
                           IRepository<OrderItem> orderItemRepo,
                           IRepository<Product> productRepo)
        {
            _authService = authService;
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
            _productRepo = productRepo;
        }

        public async Task AddToCartAsync(Product product, int quantity = 1)
        {
            var existingItem = Items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { Product = product, Quantity = quantity });
            }

            if (_authService.IsLoggedIn)
            {
                await SyncItemToDbAsync(product.ProductId, existingItem?.Quantity ?? quantity, existingItem == null);
            }

            NotifyStateChanged();
        }

        public async Task RemoveFromCartAsync(Product product)
        {
            var item = Items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            if (item != null)
            {
                Items.Remove(item);
                
                if (_authService.IsLoggedIn)
                {
                    await RemoveItemFromDbAsync(product.ProductId);
                }

                NotifyStateChanged();
            }
        }
        
        public async Task ClearCartAsync()
        {
            Items.Clear();
            if (_authService.IsLoggedIn)
            {
                await ClearDbCartAsync();
            }
            NotifyStateChanged();
        }

        public async Task LoadCartFromDbAsync(int customerId)
        {
            var cartOrder = await GetCartOrderAsync(customerId);
            if (cartOrder != null)
            {
                Items.Clear();
                foreach (var oi in cartOrder.OrderItems)
                {
                    if (oi.Product != null)
                    {
                        Items.Add(new CartItem { Product = oi.Product, Quantity = oi.Quantity });
                    }
                }
                NotifyStateChanged();
            }
            else
            {
                if (Items.Any())
                {
                     foreach(var item in Items)
                     {
                         await SyncItemToDbAsync(item.Product.ProductId, item.Quantity, true);
                     }
                }
            }
        }

        private async Task<Order?> GetCartOrderAsync(int customerId)
        {
            return await _orderRepo.Query()
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.CustomerId == customerId && (o.Status == "cart" || o.Status == "draft"));
        }

        private async Task SyncItemToDbAsync(int productId, int quantity, bool isNew)
        {
            var customerId = _authService.CurrentCustomer?.CustomerId ?? 0;
            if (customerId == 0) return;

            var order = await GetCartOrderAsync(customerId);
            if (order == null)
            {
                order = new Order
                {
                    CustomerId = customerId,
                    Status = "cart",
                    OrderDate = DateTime.Now,
                    PaymentMethod = "cash"
                };
                await _orderRepo.AddAsync(order);
                // Note: Depending on Repo/Context setup, we might need SaveChanges here if AddAsync doesn't auto-save
                // For safety in this specific "Service" architecture without explicit UnitOfWork, 
                // we assume Repositories usually handle basic saves or we need to rely on the Context being shared.
                // If this fails to generate ID, we need to inject Context directly or use a Save method.
            }

            var orderItem = order.OrderItems.FirstOrDefault(oi => oi.ProductId == productId);
            if (orderItem != null)
            {
                orderItem.Quantity = quantity;
                orderItem.Subtotal = orderItem.Quantity * (orderItem.Product?.Price ?? 0); 
                await _orderItemRepo.UpdateAsync(orderItem);
            }
            else
            {
                var product = await _productRepo.GetByIdAsync(productId);
                if (product != null)
                {
                    var newItem = new OrderItem
                    {
                        OrderId = order.OrderId, // This relies on order having an ID
                        ProductId = productId,
                        Quantity = quantity,
                        Price = product.Price,
                        Subtotal = product.Price * quantity
                    };
                    await _orderItemRepo.AddAsync(newItem);
                }
            }
        }

        private async Task RemoveItemFromDbAsync(int productId)
        {
            var customerId = _authService.CurrentCustomer?.CustomerId ?? 0;
            if (customerId == 0) return;

            var order = await GetCartOrderAsync(customerId);
            if (order != null)
            {
                var item = order.OrderItems.FirstOrDefault(oi => oi.ProductId == productId);
                if (item != null)
                {
                    await _orderItemRepo.DeleteAsync(item.OrderItemId);
                }
            }
        }

        private async Task ClearDbCartAsync()
        {
            var customerId = _authService.CurrentCustomer?.CustomerId ?? 0;
            if (customerId == 0) return;
            
             var order = await GetCartOrderAsync(customerId);
             if (order != null)
             {
                 foreach(var item in order.OrderItems.ToList())
                 {
                     await _orderItemRepo.DeleteAsync(item.OrderItemId);
                 }
             }
        }

        public decimal TotalAmount => Items.Sum(i => i.Product.Price * i.Quantity);

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
