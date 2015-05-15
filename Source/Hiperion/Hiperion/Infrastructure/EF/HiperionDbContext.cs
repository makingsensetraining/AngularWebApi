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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<Role>(user => user.Roles).WithMany(role => role.Users).Map(configuration =>
            {
                configuration.MapLeftKey("Userid");
                configuration.MapRightKey("Roleid");
                configuration.ToTable("UserHasRoles");
            });
        }

        private DbSet<User> Users { get; set; }

        private DbSet<Role> Roles { get; set; }

        public DbSet<T> Entity<T>() where T : class
        {
            return Set<T>();
        }
    }
}