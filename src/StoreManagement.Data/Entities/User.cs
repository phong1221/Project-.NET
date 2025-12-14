using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagement.Data.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("username")]
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Column("password")]
        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        [Column("full_name")]
        [StringLength(100)]
        public string? FullName { get; set; }

        [Column("role")]
        [StringLength(20)] // 'admin' or 'staff'
        public string? Role { get; set; } // Could be Enum, simple string for now

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
