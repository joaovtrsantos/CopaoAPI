using Domain.Entities;

namespace Application.Interfaces
{
    public class ITournamentRepository : IBaseRepository<Tournament>
    {
        public Task<Tournament> AddAsync(Tournament entity)
        {
            throw new NotImplementedException();
        }

        public Task<Tournament?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tournament> RemoveAsync(Tournament entity)
        {
            throw new NotImplementedException();
        }

        public Task<Tournament> UpdateAsync(Tournament entity)
        {
            throw new NotImplementedException();
        }
    }
}
