using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Data.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("category_id")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [Column("supplier_id")]
        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }

        [Column("product_name")]
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [Column("barcode")]
        [StringLength(50)]
        public string? Barcode { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("unit")]
        [StringLength(20)]
        public string? Unit { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
