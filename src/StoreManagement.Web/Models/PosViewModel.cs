using StoreManagement.Data.Entities;

namespace StoreManagement.Web.Models
{
    public class PosViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public Dictionary<string, string> PaymentMethods { get; set; } = new Dictionary<string, string>();
    }

    public class CreateOrderRequest
    {
        public int? CustomerId { get; set; }
        public string PaymentMethod { get; set; } = "cash";
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
