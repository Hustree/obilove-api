# obiLove Core API

This repository contains the backend API for the obiLove Platform, built using **.NET 9** and following **Clean Architecture** principles.

---

## 📁 Project Structure
The solution follows the **Clean Architecture** pattern with four main projects:

- **obiloveapi.Domain**: Contains business entities and domain logic
- **obiloveapi.Application**: Contains application services, DTOs, and interfaces
- **obiloveapi.Infrastructure**: Contains implementations of interfaces, data access, and external services
- **obiloveapi.API**: Contains API controllers and configuration

---

## 🚀 Getting Started

### 🔧 Prerequisites
- .NET 9 SDK
- PostgreSQL database
- Visual Studio 2022 or Visual Studio Code

### ⚙️ Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Hustree/obilove-api.git
   cd obilove-api
   ```

2. **Set up the database connection string in `appsettings.json`:**
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=obilove;Username=postgres;Password=yourpassword"
   }
   ```

3. **Apply migrations:**
   ```bash
   dotnet ef database update --project obiloveapi.Infrastructure
   ```

4. **Run the application:**
   ```bash
   dotnet run --project obiloveapi.API
   ```

---

## 🗃️ Database Migrations

### 📌 Creating a New Migration
```bash
dotnet ef migrations add MigrationName --project obiloveapi.Infrastructure
```

### 📌 Applying Migrations
```bash
dotnet ef database update --project obiloveapi.Infrastructure
```

### 📌 Generating SQL Script
```bash
dotnet ef migrations script --idempotent --output "migration.sql" --project obiloveapi.Infrastructure
```

### 📌 Removing Last Migration
```bash
dotnet ef migrations remove --project obiloveapi.Infrastructure
```

---

## ✨ Adding New Features

When adding new features, follow the **Clean Architecture** pattern:

1. **Domain Layer**: Add entities and domain logic
2. **Application Layer**: Add interfaces and service implementations
3. **Infrastructure Layer**: Add repository implementations and external services
4. **API Layer**: Add controllers and endpoints

### 📩 Example: Adding Email Notifications

1. **Domain Layer**:
   - Create `EmailNotification` entity

2. **Application Layer**:
   - Define `IEmailService` interface and DTOs

3. **Infrastructure Layer**:
   - Add database configuration in `AppDbContext`
   - Create `EmailNotificationRepository`
   - Implement `SmtpEmailProvider`

4. **API Layer**:
   - Create `EmailNotificationsController`

5. **Create and apply database migration:**
   ```bash
   dotnet ef migrations add AddEmailNotifications --project obiloveapi.Infrastructure
   dotnet ef database update --project obiloveapi.Infrastructure
   ```

---

## 🧪 Testing

### 🔍 Running Unit Tests
```bash
dotnet test
```

---

## 🚢 Deployment

### 📝 Generating Deployment Script
```bash
dotnet ef migrations script --idempotent --output "deploy.sql" --project obiloveapi.Infrastructure
```

### 🏗️ Building for Production
```bash
dotnet publish -c Release
```

---

## 🔐 Authentication

The API uses **JWT authentication**. To obtain a token:

1. Make a **POST** request to:
   ```http
   /api/auth/login
   ```
   with credentials.

2. Use the returned token in the **Authorization** header:
   ```http
   Authorization: Bearer {token}
   ```

---

## 📜 License

This project is licensed under the **MIT License** – see the [LICENSE](LICENSE) file for details.

