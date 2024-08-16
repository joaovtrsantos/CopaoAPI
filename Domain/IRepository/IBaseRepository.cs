using Domain.SeedWork;

namespace BirminghamBank.Customer.Domain.IRepository;

public interface IBaseRepository<T> : IRepository<T> where T : BaseAuditableEntity
{
    Task Add(T entity);
    Task Update(T entity);
    Task Remove(T entity);
    Task<T?> GetByIdAsync(Guid id);
}
