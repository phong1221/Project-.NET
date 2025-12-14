using StoreManagement.Data.Entities;

namespace StoreManagement.Web.Services
{
    public class CartService
    {
        public List<CartItem> Items { get; private set; } = new List<CartItem>();
        public event Action OnChange;

        public void AddToCart(Product product, int quantity = 1)
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
            NotifyStateChanged();
        }

        public void RemoveFromCart(Product product)
        {
            var item = Items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);
            if (item != null)
            {
                Items.Remove(item);
                NotifyStateChanged();
            }
        }
        
        public void ClearCart()
        {
            Items.Clear();
            NotifyStateChanged();
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
