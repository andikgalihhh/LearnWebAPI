namespace Persistence.Repositories;

public interface IGenericRepository<T> where T : class
{
    List<T> GetAll();
    T? GetById(Guid id);
    void Remove(T itemToRemove);
    void Add(T item);
    void Update(T item);
    void Delete(T itemToRemove);
    T? GetByTableNumber(Guid TableNumber);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}