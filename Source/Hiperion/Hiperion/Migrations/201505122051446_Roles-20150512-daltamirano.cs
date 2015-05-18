namespace Hiperion.Migrations
{
    #region References

    using System.Data.Entity.Migrations;

    #endregion

    public partial class Roles20150512daltamirano : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Users", "RoleId", c => c.Int());
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] {"RoleId"});
            DropColumn("dbo.Users", "RoleId");
            DropTable("dbo.Roles");
        }
    }
}