namespace Hiperion.Migrations
{
    using System.Data.Entity.Migrations;
    using Domain;
    using Infrastructure.EF;

    internal sealed class Configuration : DbMigrationsConfiguration<HiperionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HiperionDbContext context)
        {
            context.Entity<User>().AddOrUpdate(p => p.Id,
                new User
                {
                    FirstName = "John",
                    LastName = "Doe"
                });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}