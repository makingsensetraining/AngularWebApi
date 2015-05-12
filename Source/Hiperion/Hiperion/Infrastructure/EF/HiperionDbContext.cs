namespace Hiperion.Infrastructure.EF
{
    using System.Data.Entity;
    using Domain;
    using Interfaces;

    public class HiperionDbContext : DbContext, IDbContext
    {
        public HiperionDbContext() : base("HiperionDb")
        {
        }

        public HiperionDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<T> Entity<T>() where T : class
        {
            return Set<T>();
        }
    }
}