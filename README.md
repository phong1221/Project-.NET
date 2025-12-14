# Store Management System

A comprehensive web-based application for managing a retail store, built with **ASP.NET Core** (MVC for Admin, Blazor Server for Customer). This system provides a robust solution for Point of Sale (POS), inventory management, product tracking, and an online storefront for customers.

## 🚀 Features

### 🛒 Customer Portal (Blazor Server)
- **Online Storefront**: Browse products with advanced filtering (price range, category) and search capabilities.
- **Shopping Cart**: Real-time cart management.
- **User Accounts**: Registration, Login, and Profile management.
- **Order History**: Track past orders and status.
- **Responsive Design**: Optimized for desktop and mobile viewing with modern UI effects (Animate.css).

### 🛠️ Admin Dashboard (ASP.NET Core MVC)
- **Dashboard**: Overview of key metrics (Revenue, Orders, Low Stock).
- **Point of Sale (POS)**: streamlined interface for in-store checkout with product search, barcode support (simulated), and receipt generation.
- **Product Management**: CRUD operations for products, categories, and suppliers.
- **Inventory Control**: Track stock levels, import goods, and manage warehouse data.
- **Order Management**: View, confirm, and process customer and POS orders.
- **Reporting**: Visual sales reports and performance analytics.
- **Staff Management**: Manage system users and roles.
- **Notifications**: Integrated system toasts and alerts using SweetAlert2.

## 💻 Tech Stack

- **Framework**: .NET 9.0 (ASP.NET Core MVC + Blazor Server)
- **Database**: MySQL 8.0
- **ORM**: Entity Framework Core
- **Frontend**:
  - **Admin**: Bootstrap 5, jQuery, FontAwesome 6.
  - **Customer**: Blazor Components, CSS Isolation.
- **Libraries**:
  - `SweetAlert2` for notifications and dialogs.
  - `Animate.css` for UI animations.
  - `Chart.js` (if implemented in reports).

## ⚙️ Installation & Setup

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)

### 1. Database Setup
1. Create a MySQL database named `store_management`.
2. Import the initial schema/data using the SQL script provided in `Data/store_management.sql`.
   - *Alternatively, the application runs auto-migrations on startup to ensure basic schema integrity.*

### 2. Configuration
1. Open `src/StoreManagement.Web/appsettings.json`.
2. Update the `DefaultConnection` string with your MySQL credentials:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "server=localhost;user=root;password=YOUR_PASSWORD;database=store_management"
   }
   ```

### 3. Build & Run
Open a terminal in the project root and run:

```bash
cd src
dotnet restore
dotnet build
dotnet run --project StoreManagement.Web/StoreManagement.Web.csproj
```

The application will start at:
- **Admin Panel**: `https://localhost:5001/admin` (or usually redirects here from root)
- **Customer Store**: `https://localhost:5001/user`

## 🔑 Default Credentials

- **Admin User**:
  - Username: `admin` (or check database seeding)
  - Password: `123` (Default seeded password)

## 📂 Project Structure

```
StoreManagement/
├── Data/                   # Database scripts
├── src/
│   ├── StoreManagement.Data/       # EF Core DbContext and Entities
│   ├── StoreManagement.Services/   # Business Logic Layer
│   ├── StoreManagement.Web/        # Main Web App (MVC + Blazor)
│   │   ├── Components/     # Blazor Pages (Customer UI)
│   │   ├── Controllers/    # MVC Controllers (Admin UI)
│   │   ├── Views/          # Razor Views (Admin UI)
│   │   └── wwwroot/        # Static assets (CSS, JS, Images)
└── README.md
```

## 📜 License
This project is for educational and portfolio purposes.
