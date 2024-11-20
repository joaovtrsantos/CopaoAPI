using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Domain.SeedWork;

namespace Infrastructure.Data
{
    public class CopaoDbContext : DbContext, IUnitOfWork
    {
        private IConfiguration _configuration;

        public DbSet<User> User { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Tournament> Tournament { get; set; }
        public DbSet<UserTeam> UserTeam { get; set; }
        public DbSet<TeamTournament> TeamTournament { get; set; }

        public CopaoDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Connection string is empty");
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
