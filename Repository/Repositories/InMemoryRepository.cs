using Repository.Data;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories;

public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly MockDbContext _context;
    private readonly List<T> _set;

    public InMemoryRepository(MockDbContext context, System.Func<MockDbContext, List<T>> getSet)
    {
        _context = context;
        _set = getSet(context);
    }

    public IEnumerable<T> GetAll() => _set.ToList();

    public T? GetById(int id)
    {
        return _set.FirstOrDefault(e =>
        {
            var prop = e.GetType().GetProperty("Id");
            if (prop == null) return false;
            var val = prop.GetValue(e);
            return val is int i && i == id;
        });
    }

    public void Add(T entity) => _set.Add(entity);

    public void Update(T entity)
    {
        var prop = entity.GetType().GetProperty("Id");
        if (prop == null) return;
        var id = (int)(prop.GetValue(entity) ?? 0);
        var existing = GetById(id);
        if (existing == null) return;
        _set.Remove(existing);
        _set.Add(entity);
    }

    public void Remove(T entity) => _set.Remove(entity);
}
