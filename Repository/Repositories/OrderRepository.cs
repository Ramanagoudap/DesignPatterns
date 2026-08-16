using Repository.Data;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly MockDbContext _context;

    public OrderRepository(MockDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetAllOrders() => _context.Orders.ToList();

    public Order? GetOrderById(int id) => _context.Orders.FirstOrDefault(o => o.Id == id);

    public void AddOrder(Order order) => _context.Orders.Add(order);

    public void UpdateOrder(Order order)
    {
        var existing = GetOrderById(order.Id);
        if (existing == null) return;
        existing.ProductId = order.ProductId;
        existing.Quantity = order.Quantity;
        existing.Price = order.Price;
    }

    public void RemoveOrder(Order order) => _context.Orders.Remove(order);
}
