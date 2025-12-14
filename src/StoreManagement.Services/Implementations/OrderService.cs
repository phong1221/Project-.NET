using Microsoft.EntityFrameworkCore;
using StoreManagement.Data;
using StoreManagement.Data.Entities;
using StoreManagement.Services.Interfaces;

namespace StoreManagement.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly StoreManagementContext _context;

        public OrderService(StoreManagementContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(int? userId, int? customerId, int? promoId, List<(int productId, int quantity)> items, string paymentMethod, string status = "paid")
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Calculate Total & Prepare OrderItems
                decimal totalAmount = 0;
                var orderItems = new List<OrderItem>();
                
                foreach (var item in items)
                {
                    var product = await _context.Products.FindAsync(item.productId);
                    if (product == null) throw new Exception($"Product {item.productId} not found");

                    // Check inventory logic handled here or separately. For simplicity, we just check quantity.
                    var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.ProductId == item.productId);
                    if (inventory != null)
                    {
                         if(inventory.Quantity < item.quantity) throw new Exception($"Product {product.ProductName} not enough stock");
                         inventory.Quantity -= item.quantity;
                         _context.Inventories.Update(inventory);
                    }
                    else 
                    {
                         // Or create negative inventory if allowed, or throw error.
                         // For now, let's assume if no inventory record, we create one with negative or just ignore for non-stock items.
                         // We'll throw for safety.
                         throw new Exception($"Product {product.ProductName} inventory not found");
                    }

                    var subtotal = product.Price * item.quantity;
                    totalAmount += subtotal;

                    orderItems.Add(new OrderItem
                    {
                        ProductId = item.productId,
                        Quantity = item.quantity,
                        Price = product.Price,
                        Subtotal = subtotal
                    });
                }

                // 2. Apply Promotion (simplified)
                decimal discountAmount = 0;
                if (promoId.HasValue)
                {
                    var promo = await _context.Promotions.FindAsync(promoId.Value);
                    if (promo != null && promo.Status == "active" && totalAmount >= promo.MinOrderAmount)
                    {
                        if (promo.DiscountType == "percent")
                        {
                            discountAmount = totalAmount * (promo.DiscountValue / 100);
                        }
                        else
                        {
                            discountAmount = promo.DiscountValue;
                        }
                        // Update usage
                        promo.UsedCount++;
                        _context.Promotions.Update(promo);
                    }
                }

                var finalAmount = totalAmount - discountAmount;
                if (finalAmount < 0) finalAmount = 0;

                // 3. Create Order
                var order = new Order
                {
                    UserId = userId,
                    CustomerId = customerId,
                    PromoId = promoId,
                    TotalAmount = finalAmount,
                    DiscountAmount = discountAmount,
                    Status = status, 
                    OrderDate = DateTime.Now,
                    PaymentMethod = paymentMethod // Save user preference
                };

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync(); // Save to get OrderId

                // 4. Create OrderItems
                foreach(var oi in orderItems)
                {
                    oi.OrderId = order.OrderId;
                    await _context.OrderItems.AddAsync(oi);
                }

                // 5. Create Payment ONLY if paid
                if (status == "paid")
                {
                    var payment = new Payment
                    {
                        OrderId = order.OrderId,
                        Amount = finalAmount,
                        PaymentMethod = paymentMethod,
                        PaymentDate = DateTime.Now
                    };
                    await _context.Payments.AddAsync(payment);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return order;
            }
            catch(Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task ConfirmOrderAsync(int orderId, int adminUserId)
        {
             var order = await _context.Orders.FindAsync(orderId);
             if (order == null) throw new Exception("Order not found");
             if (order.Status == "paid") return; // Already paid

             // Update status and Admin User ID
             order.Status = "paid";
             order.UserId = adminUserId; // Track who confirmed it
             _context.Orders.Update(order);

             // Create Payment using the stored preference or default to COD
             var payment = new Payment
             {
                 OrderId = order.OrderId,
                 Amount = order.TotalAmount ?? 0,
                 PaymentMethod = order.PaymentMethod ?? "cod", 
                 PaymentDate = DateTime.Now
             };
             await _context.Payments.AddAsync(payment);
             
             await _context.SaveChangesAsync();
        }

         public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.User)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }
}
