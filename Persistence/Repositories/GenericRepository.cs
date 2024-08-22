using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly TableContext _context;

    public GenericRepository(TableContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Remove(T itemToRemove)
    {
        _context.Set<T>().Remove(itemToRemove);
    }
    public void Add(T itemToAdd)
    {
        _context.Set<T>().Add(itemToAdd);
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Update(T item)
    {
        throw new NotImplementedException();
    }

    public T? GetByTableNumber(Guid TableNumber)
    {
        return _context.Set<T>().Find(TableNumber);
    }

    public void Delete(T itemToRemove)
    {
        throw new NotImplementedException();
    }
}