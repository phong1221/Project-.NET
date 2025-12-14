using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Data.Entities
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("customer_id")]
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Column("promo_id")]
        public int? PromoId { get; set; }
        [ForeignKey("PromoId")]
        public Promotion? Promotion { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Column("status")]
        [StringLength(20)] // 'pending','paid','canceled'
        public string? Status { get; set; } = "pending";

        [Column("total_amount")]
        public decimal? TotalAmount { get; set; }

        [Column("discount_amount")]
        public decimal? DiscountAmount { get; set; } = 0;

        [Column("payment_method")]
        [StringLength(50)]
        public string? PaymentMethod { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
