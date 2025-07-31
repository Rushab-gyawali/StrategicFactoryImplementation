# FactoryStrategy

A .NET 8 (C# 12) solution implementing a flexible, tenant-aware background synchronization system using the Factory and Strategy design patterns. The project demonstrates dependency injection, extensible operation handling, and a simple WinForms UI for configuration.

---

## Features

- **Tenant-aware operations:** Supports multiple tenants (e.g., TenantA, TenantB) with custom sync logic.
- **Factory & Strategy patterns:** Easily extend or modify sync behaviors per operation and tenant.
- **Dependency Injection:** All services and operations are registered and resolved via DI.
- **WinForms UI:** Configure enabled sync operations (Asset, Product, Customer) per client.
- **Background Service:** Executes enabled operations asynchronously.

---

## Project Structure

- `Config/ClientConfig.cs` – Client configuration (tenant, enabled operations).
- `Models/OperationType.cs`, `Models/TenantType.cs` – Operation and tenant enums.
- `Interfaces/IOperation.cs` – Operation contract.
- `Operations/Sync/` – Operation implementations (e.g., `AssetSync`, `HeritageAssetSync`, `CustomerSync`).
- `Strategy/CustomerSync/` – Strategy implementations for customer sync.
- `Factories/OperationFactory.cs` – Factory for creating operations based on tenant and type.
- `Services/SyncBackgroundService.cs` – Orchestrates operation execution.
- `DI/DependencyInjection.cs` – DI setup and service registration.
- `Form1.cs`, `SettingsForm.cs` – WinForms UI for configuration and execution.

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or later

### Build & Run

1. **Clone the repository:**

2. **Open in Visual Studio:**  
   Open `FactoryStrategy.sln`.

3. **Restore NuGet packages:**  
   Visual Studio will restore packages automatically.

4. **Build and run:**  
   Press `F5` to build and launch the WinForms UI.

---

## Usage

1. **Configure Client:**
   - Click the **Settings** button in the main form.
   - Select which sync operations to enable (Asset, Product, Customer).
   - Save your settings.

2. **Start Sync:**
   - The background service will execute the enabled operations for the selected tenant.

---

## Extending

- **Add new operations:**  
  Implement `IOperation`, register in DI, and update `OperationFactory`.
- **Add new strategies:**  
  Implement strategy interfaces, register in DI, and update factory logic.

---

## Testing

Unit tests can be added using [xUnit](https://xunit.net/) and [Moq](https://github.com/moq/moq4):