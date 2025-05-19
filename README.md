# 🛒 E-Commerce API

This project simulates a real-world e-commerce backend system with robust architecture, validation, secure authentication, and integration with external services — all while following clean code practices.

---

## 🔧 Features

### 🔐 Authentication & Authorization
- JWT-based Auth with Refresh Tokens
- Two roles: Admin & Customer
- Email confirmation, forgot/reset password, account lock/unlock
- Role-based access control
- Permission-based access control

### 🛍️ Product Management
- Admins can create, edit, delete, and toggle product visibility
- Products grouped by types
- Cloudinary integration for uploading and managing product images

### 🛒 Cart & Wishlist System
- Customers can manage cart items and wishlists easily
- Add/update/delete items
- View cart content and wishlist by user

### 📦 Orders
- Customers place orders using their shipping addresses
- View order history
- Admin can manage order status
- 
### Payments
- Stripe integration for secure order payment handling
- Webhook support to simulate Stripe event handling

### 📝 Review System
- Customers can add/edit/delete reviews
- Fetch reviews by product or user

### 🏠 Address Management
- Manage multiple addresses per customer
- Toggle address active/inactive

### 👤 Admin Capabilities
- Admins can manage users (lock/unlock, toggle status)
- Only Admins can manage products and product types

---

## 🛠️ Tech Stack & Tools
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Mapster – for fast and simple object mapping
- FluentValidation – for robust input validation
- Cloudinary – for cloud-based image management
- Stripe – for payment gateway integration
- ASP.NET Identity – for user and role management
- Swagger – for auto-generated interactive API docs

