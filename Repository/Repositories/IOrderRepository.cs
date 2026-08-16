using Repository.Models;
using System.Collections.Generic;

namespace Repository.Repositories;

public interface IOrderRepository
{
    IEnumerable<Order> GetAllOrders();
    Order? GetOrderById(int id);
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void RemoveOrder(Order order);
}
