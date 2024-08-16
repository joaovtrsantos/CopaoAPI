using BirminghamBank.Customer.Domain.IRepository;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class BaseRepository<T>(CopaoDbContext copaoDbContext) : IBaseRepository<T> where T : BaseAuditableEntity
    {
        protected CopaoDbContext _copaoContext = copaoDbContext;
        protected DbSet<T> Set = copaoDbContext.Set<T>();

        public IUnitOfWork UnitOfWork => _copaoContext;

        public async Task Add(T entity)
        {
            await Set.AddAsync(entity);
        }
        public async Task Update(T entity)
        {
            entity.ModifiedDate = DateTime.UtcNow;
            Set.Update(entity);
            await Task.CompletedTask;
        }
        public async Task Remove(T entity)
        {
            Set.Remove(entity);
            await Task.CompletedTask;
        }
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await Set.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
