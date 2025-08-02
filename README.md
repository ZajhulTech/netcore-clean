
# 💼 BackEnd .NET Core API + SQL Server

Una aplicación desarrollada con **ASP.NET Core 8**, conectada a **SQL Server** y asegurada con **JWT**. Este proyecto demuestra habilidades en desarrollo de APIs REST, autenticación, arquitectura en capas y persistencia de datos.

---

## 📁 Estructura del Proyecto

```
/api
  └── WebApi                  # Proyecto principal ASP.NET Core Web API
  └── infrastructure          # Acceso a datos e implementación de repositorios
  └── interfaces              # Interfaces para aplicar inversión de dependencias
  └── UserStories             # Lógica de negocio (casos de uso)
  └── Models                  # DTOs y modelos compartidos
```

---

## 🚀 Tecnologías Utilizadas

- **Backend:** ASP.NET Core 8, Entity Framework Core
- **Autenticación:** JSON Web Tokens (JWT)
- **Base de datos:** SQL Server

---

## 🛠️ Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server (local o en la nube)
- (Opcional) [Visual Studio 2022 Community](https://visualstudio.microsoft.com/es/vs/community/)
- (Opcional) [Docker y Docker Compose](https://www.docker.com/)

---

## 🧱 Instalación de la Base de Datos

1. Abrir SQL Server Management Studio u otro cliente SQL.
2. Ejecutar los siguientes scripts:
   - `/sql/krispy_sales_schema.sql`
   - `/sql/vwSaleDetails.sql`
   - `/sql/data_test_generator.sql`
3. Configurar la cadena de conexión en `appsettings.json`.

---

## ▶️ Ejecución del Proyecto

### Opción 1: Visual Studio

1. Abrir la solución `KrispyKremeSales.sln`.
2. Asegurarse que `WebApi` esté seleccionado como proyecto de inicio.
3. Ejecutar con F5.

### Opción 2: Terminal / Visual Studio Code

```bash
cd api/WebApi
dotnet restore
dotnet build
dotnet run
```

API disponible en: [https://localhost:7299](https://localhost:7299)  
Swagger: [http://localhost:7299/swagger](http://localhost:7299/swagger)

---

## ⚙️ Funcionalidades

### 🔹 Backend (.NET Core)
- API RESTful estructurada en capas
- Autenticación con JWT
- CRUD de ventas
- Validación y manejo de errores
- Script SQL de inicialización

---

## 🐳 Levantamiento en Docker

### Crear imagen backend
```bash
docker build -t sales-module-api:master -f api/WebApi/Dockerfile .
```

### Subir imagen (opcional)
```bash
docker push sales-module-api:master
```

### Levantar entorno
```bash
docker-compose up --build
```

---

## 🧰 Comandos para Crear Esta Plantilla (.NET 8)

```bash
# Crear solución
dotnet new sln -o PaymentDemo

# Crear proyectos base
dotnet new webapi -n PaymentDemo.WebApi --use-controllers -o PaymentDemo.WebApi -f net8.0
dotnet new classlib -n PaymentDemo.Infra -o PaymentDemo.Infra -f net8.0
dotnet new classlib -n PaymentDemo.Models -o PaymentDemo.Models -f net8.0
dotnet new classlib -n PaymentDemo.UserStorys -o PaymentDemo.UserStorys -f net8.0
dotnet new classlib -n PaymentDemo.Interfaces -o PaymentDemo.Interfaces -f net8.0

# Agregar proyectos a la solución
dotnet sln PaymentDemo.sln add PaymentDemo.WebApi/PaymentDemo.WebApi.csproj
dotnet sln PaymentDemo.sln add PaymentDemo.Infra/PaymentDemo.Infra.csproj
dotnet sln PaymentDemo.sln add PaymentDemo.Models/PaymentDemo.Models.csproj
dotnet sln PaymentDemo.sln add PaymentDemo.UserStorys/PaymentDemo.UserStorys.csproj
dotnet sln PaymentDemo.sln add PaymentDemo.Interfaces/PaymentDemo.Interfaces.csproj

# Referencias entre proyectos
dotnet add PaymentDemo.Infra/PaymentDemo.Infra.csproj reference PaymentDemo.Models/PaymentDemo.Models.csproj
dotnet add PaymentDemo.Infra/PaymentDemo.Infra.csproj reference PaymentDemo.Interfaces/PaymentDemo.Interfaces.csproj
dotnet add PaymentDemo.WebApi/PaymentDemo.WebApi.csproj reference PaymentDemo.Infra/PaymentDemo.Infra.csproj
dotnet add PaymentDemo.WebApi/PaymentDemo.WebApi.csproj reference PaymentDemo.UserStorys/PaymentDemo.UserStorys.csproj
dotnet add PaymentDemo.UserStorys/PaymentDemo.UserStorys.csproj reference PaymentDemo.Models/PaymentDemo.Models.csproj
dotnet add PaymentDemo.UserStorys/PaymentDemo.UserStorys.csproj reference PaymentDemo.Interfaces/PaymentDemo.Interfaces.csproj

# Entity Framework Core (Infra)
cd PaymentDemo.Infra
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design

# Ejemplo de scaffolding (si usas DB first)
dotnet ef dbcontext scaffold "Server=localhost;Database=TuDB;User Id=usuario;Password=clave;" \
Microsoft.EntityFrameworkCore.SqlServer \
--project PaymentDemo.Infra \
--output-dir Persistence/Models
```

---

## 🔐 Ejemplo de cadena de conexión

```text
Server=demo_control.mssql.somee.com;
Database=demo_control;
User Id=SaulDuenas_SQLLogin_1;
Password=elmasmejor;
TrustServerCertificate=true;
```

---

## 📌 Notas Finales

Este proyecto sirve como plantilla base para la construcción de microservicios con arquitectura limpia, JWT y SQL Server. Puede ser escalado y adaptado fácilmente para entornos Docker/Kubernetes o soluciones empresariales.
