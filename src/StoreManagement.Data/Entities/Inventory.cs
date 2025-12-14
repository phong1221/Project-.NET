using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Data.Entities
{
    [Table("inventory")]
    public class Inventory
    {
        [Key]
        [Column("inventory_id")]
        public int InventoryId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; } = 0;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
