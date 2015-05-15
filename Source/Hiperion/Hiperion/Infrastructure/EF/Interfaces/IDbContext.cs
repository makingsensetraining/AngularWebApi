namespace Hiperion.Infrastructure.EF.Interfaces
{
    #region References

    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    #endregion

    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        IDbSet<TEntity> Entity<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}