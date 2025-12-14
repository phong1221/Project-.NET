using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Data.Entities
{
    [Table("categories")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("category_name")]
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;
    }
}
