﻿namespace Hiperion.Domain.Mappings
{
    using System.Data.Entity.ModelConfiguration;

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            HasKey(role => role.Id);

            //Properties
            Property(t => t.Id).HasColumnName("Id");
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