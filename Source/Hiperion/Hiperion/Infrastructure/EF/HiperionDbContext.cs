namespace Hiperion.Infrastructure.EF
{
    #region References

    using System.Data.Entity;
    using Domain;
    using Domain.Mappings;
    using Interfaces;

    #endregion

    public class HiperionDbContext : DbContext, IDbContext
    {
        public HiperionDbContext() : base("HiperionDb")
        {
        }

        public HiperionDbContext(string connectionString) : base(connectionString)
        {
        }

        private IDbSet<Role> Roles { get; set; }

        private IDbSet<Country> Countries { get; set; }

        private IDbSet<User> Users { get; set; }

        public virtual IDbSet<T> Entity<T>() where T : class
        {
            return Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}