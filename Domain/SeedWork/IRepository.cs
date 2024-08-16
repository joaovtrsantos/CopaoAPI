using Domain.SeedWork;

public interface IRepository<T>
{
    public IUnitOfWork UnitOfWork { get; }
}