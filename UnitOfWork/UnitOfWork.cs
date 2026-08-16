using Repository.Data;
using Repository.Repositories;
using UnitOfWork.Interfaces;

namespace UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly MockDbContext _context;
    private ProductRepository? _productRepository;
    private OrderRepository? _orderRepository;
    private bool _completed;

    public UnitOfWork()
    {
        _context = new MockDbContext();
        _context.BeginTransaction();
    }

    public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
    public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);

    public int Commit()
    {
        try
        {
            _context.SaveChanges();
            _context.CommitTransaction();
            _completed = true;
            return 1; // mock affected rows
        }
        catch
        {
            _context.RollbackTransaction();
            throw;
        }
    }

    public void Dispose()
    {
        if (!_completed)
        {
            _context.RollbackTransaction();
        }
    }
}
