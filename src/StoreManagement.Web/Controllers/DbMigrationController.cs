using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data;

namespace StoreManagement.Web.Controllers
{
    public class DbMigrationController : Controller
    {
        private readonly StoreManagementContext _context;

        public DbMigrationController(StoreManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> RunMigration()
        {
            try 
            {
                // Simple attempt to add the column if it doesn't exist
                // Note: In production, use proper EF Migrations. This is a quick fix for the session.
                 await _context.Database.ExecuteSqlRawAsync("ALTER TABLE customers ADD COLUMN password VARCHAR(255) NULL;");
                 return Content("Migration 'Add Password' Attempted.");
            }
            catch (Exception ex)
            {
                return Content($"Migration might have already run or failed: {ex.Message}");
            }
        }
    }
}
