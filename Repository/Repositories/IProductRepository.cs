using Repository.Models;
using System.Collections.Generic;

namespace Repository.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void RemoveProduct(Product product);
}
