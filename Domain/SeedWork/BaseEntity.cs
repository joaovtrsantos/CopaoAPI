namespace Domain.SeedWork
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
