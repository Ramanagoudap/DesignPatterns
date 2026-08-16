using Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Data;

public class MockDbContext
{
    // Global in-memory storage to simulate a database that survives context instances
    private static readonly List<Product> _globalProducts = new();
    private static readonly List<Order> _globalOrders = new();

    // Instance views over the global storage
    public List<Product> Products => _globalProducts;
    public List<Order> Orders => _globalOrders;

    private List<Product>? _productsSnapshot;
    private List<Order>? _ordersSnapshot;
    private bool _inTransaction;

    // Begin a simple transaction by snapshotting current state
    public void BeginTransaction()
    {
        if (_inTransaction) return;
        _productsSnapshot = Products.Select(p => p.Clone()).ToList();
        _ordersSnapshot = Orders.Select(o => o.Clone()).ToList();
        _inTransaction = true;
    }

    public void CommitTransaction()
    {
        _productsSnapshot = null;
        _ordersSnapshot = null;
        _inTransaction = false;
    }

    public void RollbackTransaction()
    {
        if (!_inTransaction) return;
        Products.Clear();
        Products.AddRange(_productsSnapshot ?? Enumerable.Empty<Product>());

        Orders.Clear();
        Orders.AddRange(_ordersSnapshot ?? Enumerable.Empty<Order>());

        _productsSnapshot = null;
        _ordersSnapshot = null;
        _inTransaction = false;
    }

    // Simulate saving changes in a real DbContext
    public void SaveChanges()
    {
        // No-op for mock, but could contain logging or validation
    }
}
