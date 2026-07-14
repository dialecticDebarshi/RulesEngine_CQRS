# RulesEngine_CQRS
A scalable .NET Core rules engine POC utilizing NRules and RulesEngine. Features a Clean Architecture solution (4 projects) with MediatR and custom DI to keep the API clean. Rules are database-persistent with an audit trail, using EF Core for writes and Dapper for reads. Future roadmap includes Azure Functions &amp; Service Bus for event-driven logic.
