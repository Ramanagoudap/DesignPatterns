using UnitOfWork;
using Repository.Models;

// Demonstration of a more realistic UnitOfWork usage where multiple repositories are coordinated and committed as a single transaction.
using (var uow = new UnitOfWork.UnitOfWork())
{
    try
    {
        // Add products
        uow.Products.AddProduct(new Product { Id = 1, Name = "Pencil", Price = 0.5m });
        uow.Products.AddProduct(new Product { Id = 2, Name = "Eraser", Price = 0.25m });

        // Create an order that references a product
        uow.Orders.AddOrder(new Repository.Models.Order { Id = 1, ProductId = 1, Quantity = 10, Price = 0.5m });

        Console.WriteLine("Before commit:");
        Console.WriteLine("Products:");
        foreach (var p in uow.Products.GetAllProducts()) Console.WriteLine($"{p.Id}: {p.Name} - {p.Price:C}");
        Console.WriteLine("Orders:");
        foreach (var o in uow.Orders.GetAllOrders()) Console.WriteLine($"{o.Id}: Product {o.ProductId} x{o.Quantity} = {o.Total:C}");

        // Commit all changes as one atomic operation
        uow.Commit();
        Console.WriteLine("Transaction committed.");
    }
    catch (System.Exception ex)
    {
        // On exception, disposal will rollback the transaction
        Console.WriteLine($"Error: {ex.Message}. Transaction rolled back.");
    }
}

// Demonstrate rollback by causing an error
using (var uow = new UnitOfWork.UnitOfWork())
{
    try
    {
        uow.Products.AddProduct(new Product { Id = 3, Name = "Marker", Price = 1.25m });
        // Simulate error
        throw new System.InvalidOperationException("Simulated failure");
    }
    catch
    {
        // disposal will rollback
    }
}

// Start a new unit to show that previous transaction was rolled back
using (var uow = new UnitOfWork.UnitOfWork())
{
    Console.WriteLine("After rollback, products:");
    foreach (var p in uow.Products.GetAllProducts()) Console.WriteLine($"{p.Id}: {p.Name} - {p.Price:C}");
}
