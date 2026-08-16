using Repository.Repositories;

namespace UnitOfWork.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    int Commit();
}
