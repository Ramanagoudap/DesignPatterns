# Repository Pattern

The Repository pattern mediates between the domain and data mapping layers, acting like an in-memory collection of domain objects. 
It separates data access concerns from business logic and provides a cleaner abstraction for querying and persisting data.

## Intent
- Encapsulate data access logic.
- Provide a collection-like interface for domain objects.
- Make unit testing easier by allowing mocking or in-memory implementations.

## Example (simple in-memory)
- MockDbContext: simple in-memory holder for entity lists.
- IRepository<T>: generic repository interface.
- InMemoryRepository<T>: generic in-memory repository using MockDbContext.
- IProductRepository / ProductRepository: concrete repository for Product entity.

## When to use
- When you want a clear separation between business logic and data access.
- When you want to be able to swap data stores or mock data access for tests.

## Drawbacks
- Can add extra layers and boilerplate when using simple ORMs that already provide rich APIs.

