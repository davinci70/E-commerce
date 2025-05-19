# 🛒 E-Commerce API

This project is a fully-featured **RESTful E-Commerce API** built with **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**. It serves as the backend of an e-commerce platform supporting multiple roles such as Admin and Customer, and covers all major functionalities required for an online shopping system.

---

## 🔧 Features

### 🧑‍💼 Account & Authentication
- User registration & login (JWT & Refresh Tokens)
- Email confirmation & password reset
- Role-based authorization (Admin, Customer)
- Change password and update profile

### 📦 Product Management
- Add, update, delete products
- Toggle product status for soft deletion
- Support for multiple product types
- Associate products with multiple images and types

### 🛒 Cart & Orders
- Customer cart management
- Add/remove items
- Place orders and view order history
- Toggle order status

### 💳 Payment
- Handle order payments
- Simulated webhook endpoint for external integrations

### ✍️ Reviews
- Add/edit/delete customer product reviews
- Fetch reviews by product

### 💡 Wishlist
- Add/remove items to/from wishlist
- Get customer's wishlist

### 🧾 Address Management
- CRUD operations on customer addresses
- Toggle address status
- Link addresses to customer profiles

### 🔐 Role Management
- Create and assign roles
- Enable/disable roles

---

## 🧱 Tech Stack
- **Backend**: ASP.NET Core / C#
- **Database**: SQL Server
- **ORM**: Entity Framework Core

