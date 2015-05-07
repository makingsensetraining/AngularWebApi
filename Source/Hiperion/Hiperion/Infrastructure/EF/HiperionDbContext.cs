using System.Data.Entity;
using Hiperion.Domain;
using Hiperion.Infrastructure.EF.Interfaces;

namespace Hiperion.Infrastructure.EF
{
    public class HiperionDbContext : DbContext, IDbContext
    {
        public HiperionDbContext(string connectionString) : base(connectionString) { }

        public DbSet<User> UserSet { get; set; }

        public DbSet<T> Entity<T>() where T : class
        {
            return this.Set<T>();
        }
    }
}