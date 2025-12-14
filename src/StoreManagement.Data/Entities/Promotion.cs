using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Data.Entities
{
    [Table("promotions")]
    public class Promotion
    {
        [Key]
        [Column("promo_id")]
        public int PromoId { get; set; }

        [Column("promo_code")]
        [Required]
        [StringLength(50)]
        public string PromoCode { get; set; } = string.Empty;

        [Column("description")]
        [StringLength(255)]
        public string? Description { get; set; }

        [Column("discount_type")]
        [Required]
        [StringLength(20)]
        public string DiscountType { get; set; } = "percent"; // 'percent' or 'fixed'

        [Column("discount_value")]
        public decimal DiscountValue { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("min_order_amount")]
        public decimal MinOrderAmount { get; set; } = 0;

        [Column("usage_limit")]
        public int UsageLimit { get; set; } = 0;

        [Column("used_count")]
        public int UsedCount { get; set; } = 0;

        [Column("status")]
        [StringLength(20)]
        public string? Status { get; set; } = "active"; // 'active', 'inactive'

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}
