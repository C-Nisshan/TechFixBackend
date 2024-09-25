# TechFix Backend

## Overview

TechFix Backend is a procurement management system designed for a local computer shop, TechFix. It streamlines the procurement process by automating tasks like requesting quotes from suppliers, placing orders, managing inventory, and handling user authentication for staff members.

This project uses **ASP.NET Core** for the backend and integrates with **Microsoft SQL Server** for data management.

## Installation

### 1. Clone the Repository

First, clone the repository to your local machine:

```bash
git clone https://github.com/YOUR_USERNAME/TechFixBackend.git
cd TechFixBackend
```


### 2. Install Dependencies
To install the project dependencies, run the following command in the TechFixBackend project folder

```bash
dotnet restore
```
This will install all necessary NuGet packages.


### 3. Set Up the Database
1. Ensure you have Microsoft SQL Server installed and running.

2. Configure the connection string in the appsettings.json file, located in the TechFixBackend folder. Here’s an example
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TechFixDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```
3. Run the following commands to apply database migrations and update the database schema
```bash
dotnet ef database update
```
This will create all necessary tables (e.g., Users, Products, Suppliers, Quotes, Orders, etc.) in the TechFixDB database.



### 4. Running the Application
To start the application locally
```bash
dotnet run
```

## Features
1. **User Authentication**
   - Roles: Admin and Procurement Staff.
   - Authentication: Users are required to log in with their credentials to access the system.
   - Passwords are securely hashed using SHA256.

2. **Inventory Management**
   - Suppliers provide real-time inventory data that is synchronized with the system.
   - Track products, stock levels, and supplier details in the Inventory table.

3. **Quote Requests**
   - Procurement staff can request quotes from suppliers, providing information such as products, quantities, and expected delivery dates.
   - The Quotes and QuoteItems tables track the quote details.

4. **Order Placement**
   - Orders can be placed based on quotes or as direct purchases.
   - The Orders and OrderItems tables record all purchase details, including the supplier, products, and prices.


### 6. Additional Information
1. **Folder Structure**
   - `TechFixBackend.sln`: Solution file.
   - `TechFixBackend/`: Contains the core project files (models, controllers, services, etc.).
   - `appsettings.json`: Configuration file for database connections and other settings.

2. **Technologies Used**
   - **ASP.NET Core 8.0**
   - **Microsoft SQL Server**
   - **Entity Framework Core** for database access
   - **JWT Authentication** for secure login


### License
This project is open-source and available under the [MIT License](https://opensource.org/licenses/MIT).


