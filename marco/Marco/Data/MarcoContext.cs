using Marco.Models;
using Microsoft.EntityFrameworkCore;

namespace Marco.Data
{
    public abstract class MarcoContext<TContext> : DbContext where TContext : MarcoContext<TContext>
    {
        private readonly string _connectionString;
        protected MarcoContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected MarcoContext(DbContextOptions<TContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!String.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }       
        public DbSet<HealthCheckEntity> HealthCheck { get; set; }
    }
}
