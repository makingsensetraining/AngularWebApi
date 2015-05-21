namespace Hiperion.Domain.Mappings
{
    #region References

    using System.Data.Entity.ModelConfiguration;

    #endregion

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            HasKey(role => role.Id);

            //Properties
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.UserName).HasColumnName("UserName");
            Property(t => t.Password).HasColumnName("Password");
            Property(t => t.FirstName).HasColumnName("FirstName");
            Property(t => t.LastName).HasColumnName("LastName");
            Property(t => t.Age).HasColumnName("Age");

            // Relationships
            HasMany(t => t.Roles)
                .WithMany(t => t.Users)
                .Map(m =>
                {
                    m.ToTable("UserHasRoles");
                    m.MapLeftKey("Userid");
                    m.MapRightKey("Roleid");
                }
                );
        }
    }
}