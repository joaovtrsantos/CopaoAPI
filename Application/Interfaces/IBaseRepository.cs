namespace Application.Interfaces;

public interface IBaseRepository<T>
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> RemoveAsync(T entity);
    Task<T?> GetByIdAsync(int id);
}
