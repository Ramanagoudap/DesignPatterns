using Repository.Data;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MockDbContext _context;

    public ProductRepository(MockDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAllProducts() => _context.Products.ToList();

    public Product? GetProductById(int id) => _context.Products.FirstOrDefault(p => p.Id == id);

    public void AddProduct(Product product) => _context.Products.Add(product);

    public void UpdateProduct(Product product)
    {
        var existing = GetProductById(product.Id);
        if (existing == null) return;
        existing.Name = product.Name;
        existing.Price = product.Price;
    }

    public void RemoveProduct(Product product) => _context.Products.Remove(product);
}
