using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Domain.SeedWork;

namespace Infrastructure.Data
{
    public class CopaoDbContext(IConfiguration configuration, DbContextOptions options) : DbContext(options), IUnitOfWork
    {
        private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        public DbSet<User> User { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Tournament> Tournament { get; set; }
        public DbSet<UserTeam> UserTeam { get; set; }
        public DbSet<TeamTournament> TeamTournament { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Connection string is empty");
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
