namespace Domain.SeedWork
{
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
