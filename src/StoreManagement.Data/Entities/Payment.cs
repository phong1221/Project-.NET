using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Data.Entities
{
    [Table("payments")]
    public class Payment
    {
        [Key]
        [Column("payment_id")]
        public int PaymentId { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("payment_method")]
        [StringLength(50)] // 'cash','card','bank_transfer','e-wallet'
        public string? PaymentMethod { get; set; } = "cash";

        [Column("payment_date")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
