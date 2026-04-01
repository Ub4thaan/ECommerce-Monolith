\# E-Commerce Monolith - Clean Architecture \& DDD

A complete \*\*enterprise-grade E-commerce\*\* application developed as a \*\*Monolith\*\* using modern .NET best practices.



Built with \*\*Clean Architecture\*\*, \*\*Domain-Driven Design (DDD)\*\* and full adherence to \*\*SOLID principles\*\*, this project showcases how to structure a complex application while keeping high maintainability, testability, and domain clarity.

---

**⚠️ This project is under active development**

The `main` branch contains the latest stable (or previously released) version.  
**Active development happens on the [`developing`](https://github.com/Ub4thaan/ECommerce-Monolith/tree/developing) branch.**

---

\## 🎯 Project Goals



\- Strictly apply \*\*Clean Architecture\*\* (Domain, Application, Infrastructure, Presentation layers)

\- Model the domain using \*\*DDD\*\* (Aggregates, Entities, Value Objects, Domain Events, Bounded Contexts)

\- Fully respect the \*\*5 SOLID principles\*\*

\- Use \*\*MediatR\*\* for Commands, Queries and \*\*Domain Events\*\* handling

\- Demonstrate a scalable and evolvable architecture in a monolithic context

\- Strong focus on \*\*domain expressiveness\*\* and \*\*separation of concerns\*\*



\## 🏗️ Architecture



The project strictly follows \*\*Clean Architecture\*\*:

```bash

src/

├── ECommerce.Domain/          ← Domain Core (Entities, Aggregates, Value Objects, Domain Events, Exceptions)

├── ECommerce.Application/      ← Use Cases, Commands, Queries, DTOs, Interfaces, MediatR Handlers

├── ECommerce.Infrastructure/   ← Implementations (EF Core, Repositories, Identity, Email, Payment, etc.)

└── ECommerce.Web/              ← Presentation Layer (ASP.NET Core Web API)

```



\### Main Bounded Contexts (to implement):

\- \*\*Catalog\*\* (Products, Categories, Brands)

\- \*\*Sales / Orders\*\* (Orders, OrderItems, Payments)

\- \*\*Customers / Identity\*\*

\- \*\*Basket\*\* (Shopping Cart)



\## ✨ Key Features



\- \*\*Full DDD implementation\*\*:

&#x20; - Rich Domain Model

&#x20; - Protected Aggregates with business invariants

&#x20; - Immutable Value Objects

&#x20; - Domain Events published via MediatR

\- \*\*CQRS\*\* pattern (clear separation between commands and queries)

\- \*\*Entity Framework Core 8\*\* with advanced configurations

\- \*\*Repository Pattern\*\* + \*\*Unit of Work\*\* (when needed)

\- \*\*FluentValidation\*\* for command validation

\- \*\*AutoMapper\*\* or explicit manual mapping

\- \*\*Customized ASP.NET Core Identity\*\*

\- \*\*Swagger / OpenAPI\*\* documentation

\- Centralized \*\*Exception Handling\*\* and \*\*Logging\*\*

\- \*\*Health Checks\*\*

\- \*\*Docker support\*\* (optional)



\## 🛠️ Technologies



\- \*\*.NET 8\*\*

\- \*\*C# 12\*\*

\- \*\*ASP.NET Core Web API\*\*

\- \*\*Entity Framework Core\*\*

\- \*\*MediatR\*\*

\- \*\*FluentValidation\*\*

\- \*\*xUnit + FluentAssertions + Moq\*\* (for testing)

\- \*\*Docker\*\* (optional)



\## 📁 Project Structure



```bash

src/

├── ECommerce.Domain/

│   ├── Common/

│   ├── Products/

│   ├── Orders/

│   ├── Customers/

│   └── SharedKernel/

├── ECommerce.Application/

│   ├── Features/

│   ├── Common/

│   └── Interfaces/

├── ECommerce.Infrastructure/

│   ├── Persistence/

│   ├── Identity/

│   ├── Services/

│   └── DependencyInjection.cs

└── ECommerce.Web/

&#x20;   ├── Controllers/

&#x20;   ├── Endpoints/

&#x20;   ├── Program.cs

&#x20;   └── appsettings.json

```

\## 🚀 How to Run



Clone the repository:

```bash

git clone https://github.com/ub4thaan/ecommerce-monolith.git

```

2\. Navigate to the project:

```bash

cd ecommerce-monolith

```

3\. Update the connection string in src/ECommerce.Web/appsettings.json

4\. Apply database migrations:

```bash

dotnet ef database update --project src/ECommerce.Infrastructure --startup-project src/WebApi

```

5\. Run the application:

```bash

dotnet run --project src/WebApi

```



\## 📖 Documentation



Architecture and Design Decisions

Development Guide

Domain Model

How to Add a New Bounded Context



\## 🤝 Contributing



This project serves primarily as a reference architecture.

Contributions are welcome via issues or pull requests for:



Domain improvements

New use cases

Performance optimizations

Test enhancements



\## 📄 License



This project is licensed under the GPL 3.0 License.



\---



Built with passion for software craftsmanship and clean architectures.

If you like this approach, please leave a ⭐!

