using BirminghamBank.Customer.Domain.IRepository;
using Domain.Entities;
using Domain.SeedWork;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class TournamentRepository(CopaoDbContext copaoDbContext) : IBaseRepository<Tournament>
    {
        private readonly CopaoDbContext _context = copaoDbContext;

        public async Task<Tournament> AddAsync(Tournament tournament)
        {
            ArgumentNullException.ThrowIfNull(tournament);

            await _context.Set<Tournament>().AddAsync(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

        public async Task<Tournament?> GetByIdAsync(int id)
        {
            return await _context.Set<Tournament>()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            return await _context.Set<Tournament>().ToListAsync();
        }

        public async Task<Tournament> RemoveAsync(Tournament tournament)
        {
            ArgumentNullException.ThrowIfNull(tournament);

            _context.Set<Tournament>().Remove(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }

        public async Task<Tournament> UpdateAsync(Tournament tournament)
        {
            ArgumentNullException.ThrowIfNull(tournament);

            _context.Set<Tournament>().Update(tournament);
            await _context.SaveChangesAsync();
            return tournament;
        }
    }
}