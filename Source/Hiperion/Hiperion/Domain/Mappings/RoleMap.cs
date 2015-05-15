namespace Hiperion.Domain.Mappings
{
    #region References

    using System.Data.Entity.ModelConfiguration;

    #endregion

    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Primary Key
            HasKey(role => role.Id);

            //Properties
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}