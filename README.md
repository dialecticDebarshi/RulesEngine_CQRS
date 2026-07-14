# Custom .NET Core Rules Engine POC

A highly scalable, production-ready Rules Engine implementation in .NET Core. This proof-of-concept showcases a hybrid approach, integrating two popular open-source libraries—**NRules** and **RulesEngine**—within a clean, decoupled architecture.

## 🚀 Architecture & Design Principles

The solution is strictly organized into **4 projects** adhering to **Clean Architecture** guidelines:
* **Domain:** Contains core entities, business rules definitions, and domain logic.
* **Application:** Handles application workflows, command/query handling, and orchestration.
* **Infrastructure:** Manages external concerns such as database context, persistence, and third-party integrations.
* **API (Presentation):** The entry point of the application, kept exceptionally lightweight.

### Key Architectural Highlights
* **Clean Program.cs:** Leverages **MediatR** to handle requests/responses pipelines, keeping controller and startup logic minimal. Dependency Injection (DI) is isolated into a dedicated extension class to prevent configuration bloat.
* **CQRS / Hybrid ORM Pattern:** * **EF Core (Write Path):** Utilized for transaction management, state changes, and maintaining a strict **Audit Trail** of executed rules.
    * **Dapper (Read Path):** Used for lightning-fast, high-performance querying of rules and audit logs from the database.
* **Persistent Rules:** Rules are stored dynamic-dynamically in the database rather than hardcoded, allowing for runtime updates without redeploying the application.

## 🛠️ Tech Stack
* **Framework:** .NET Core
* **Rule Engines:** NRules & Microsoft RulesEngine
* **Mediation:** MediatR
* **Persistence:** EF Core (Writes) & Dapper (Reads)
* **Database:** SQL Server / PostgreSQL (Persistent & Audited)

## 🔮 Future Roadmap: Event-Driven Evolution
To scale rule execution asynchronously, the next phase of this repository will introduce an **Event-Driven Architecture**:
1.  **Azure Service Bus:** To ingest incoming rule evaluation requests and broadcast rule execution results via topics/subscriptions.
2.  **Azure Functions:** Serverless triggers to execute rules out-of-process, decoupling the main API from heavy computation workloads.

## ⚡ Getting Started
1. Clone the repository.
2. Update the connection string in the API's `appsettings.json`.
3. Run the database migrations (EF Core) to generate the rule schema and audit trail tables.
4. Build and run the solution.
