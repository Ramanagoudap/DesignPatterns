using Repository.Data;
using Repository.Models;
using Repository.Repositories;

var context = new MockDbContext();
var products = new ProductRepository(context);

products.AddProduct(new Product { Id = 1, Name = "Pen", Price = 1.5m });
products.AddProduct(new Product { Id = 2, Name = "Notebook", Price = 3.0m });

Console.WriteLine("Products in repository:");
foreach (var p in products.GetAllProducts())
{
    Console.WriteLine($"{p.Id}: {p.Name} - {p.Price:C}");
}

// Persist (noop for mock)
context.SaveChanges();
