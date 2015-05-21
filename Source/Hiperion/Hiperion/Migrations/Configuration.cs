namespace Hiperion.Migrations
{
    #region References

    using System.Data.Entity.Migrations;
    using Domain;
    using Infrastructure.EF;

    #endregion

    internal sealed class Configuration : DbMigrationsConfiguration<HiperionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HiperionDbContext context)
        {
            context.Entity<Country>().AddOrUpdate(p => p.Id,
                new Country
                {
                    Id = 1,
                    Name = "Argentina"
                },
                new Country
                {
                    Id = 2,
                    Name = "Brasil"
                },
                new Country
                {
                    Id = 3,
                    Name = "Chile"
                }
                );

            context.Entity<Role>().AddOrUpdate(role => role.Id,
                new Role
                {
                    Id = 1,
                    Name = "Administrator"
                },
                new Role
                {
                    Id = 2,
                    Name = "User"
                },
                new Role
                {
                    Id = 3,
                    Name = "Collaborator"
                });

            context.Entity<User>().AddOrUpdate(p => p.Id,
                new User
                {
                    Id = 1,
                    UserName = "john@mail.com",
                    Password = "B4B37559DDAAF2D4187D7EA521C88F64", /*test#1234*/
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 50,
                    CountryId = 1,
                });
        }
    }
}