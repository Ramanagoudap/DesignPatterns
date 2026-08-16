# Unit of Work Pattern

The Unit of Work pattern maintains a list of objects affected by a business transaction and coordinates the writing out of changes as a single atomic operation. 
It helps to keep related operations together and minimizes the number of database calls.

## Intent
- Coordinate changes across multiple repositories as a single transaction.
- Keep business logic atomic and consistent.
- Reduce coupling between application code and data persistence.

## Example (mocked)
- UnitOfWork class holds a shared MockDbContext and exposes repository properties (Products, Orders).
- The UnitOfWork begins a transaction, operations across repositories are recorded against the shared DbContext, and Commit() finalizes the transaction. If an error occurs, the UnitOfWork rolls back to the state before the transaction began.

## When to use
- When multiple repository operations must be committed together.
- When using ORMs where a DbContext or session tracks changes across entities.

## Drawbacks
- Adds coordination layer and can be unnecessary if the ORM already manages transactions cleanly for your use-case.

