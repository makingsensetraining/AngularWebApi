namespace Hiperion.Domain.Mappings
{
    using System.Data.Entity.ModelConfiguration;

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