using System.Data.Entity;
using Hiperion.Domain;
using Hiperion.Infrastructure.EF.Interfaces;

namespace Hiperion.Infrastructure.EF
{
    public class UserContext : DbContext, IDbContext
    {
        public UserContext(){}

        public UserContext(string connstring) : base(connstring) { }

        public DbSet<User> UserSet { get; set; }

        public DbSet<T> Entity<T>() where T : class
        {
            return this.Set<T>();
        }
    }
}