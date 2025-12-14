using Microsoft.AspNetCore.Components.Web;
using StoreManagement.Web.Components;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data;
using StoreManagement.Services.Interfaces;
using StoreManagement.Services.Implementations;
using StoreManagement.Data.Repositories;
using StoreManagement.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// NEW: Add Server Side Blazor
builder.Services.AddServerSideBlazor();

// Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreManagementContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Existing Services
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// NEW: Blazor Services
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<CustomerAuthService>();

// Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/admin/Auth/Login";
        options.AccessDeniedPath = "/admin/Auth/AccessDenied";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// NEW: Map Blazor Hub
app.MapBlazorHub();

// 1. User/Store Route (Blazor)
// Any path starting with "user" is handled by UserController.Index (which hosts Blazor)
app.MapControllerRoute(
    name: "user",
    pattern: "user/{*path}",
    defaults: new { controller = "User", action = "Index" });

// 2. Admin Routes
// We want "admin/" to be the dashboard
// Call /admin -> Home/Index
app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}");

// 3. Fallback / Redirect
app.MapGet("/", async context => {
    context.Response.Redirect("/admin");
    await Task.CompletedTask;
});

// Auto-migration for Password column (Fix for crash)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<StoreManagementContext>();
    try
    {
        // Check if column exists or just try to add it. 
        // Note: 'ADD COLUMN IF NOT EXISTS' is supported in newer MySQL/MariaDB. 
        // For broad compatibility, we catch exception if it exists.
        await context.Database.ExecuteSqlRawAsync("ALTER TABLE customers ADD COLUMN password VARCHAR(255) NULL;");
        
        // Seed default password for existing users so they can login
        await context.Database.ExecuteSqlRawAsync("UPDATE customers SET password = '123' WHERE password IS NULL;");

        // NEW: Add payment_method to orders table to store user preference
        await context.Database.ExecuteSqlRawAsync("ALTER TABLE orders ADD COLUMN payment_method VARCHAR(50) NULL;");
    }
    catch
    {
        // Ignore "Duplicate column name" error if run multiple times
        // Attempt to seed password anyway in case column existed but was null
        try {
             await context.Database.ExecuteSqlRawAsync("UPDATE customers SET password = '123' WHERE password IS NULL;");
        } catch {}
        
        try {
             await context.Database.ExecuteSqlRawAsync("ALTER TABLE orders ADD COLUMN payment_method VARCHAR(50) NULL;");
        } catch {}
    }
}

app.Run();
